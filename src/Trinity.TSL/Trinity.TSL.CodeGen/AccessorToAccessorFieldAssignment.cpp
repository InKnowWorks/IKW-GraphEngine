#include "common.h"
#include "AccessorType.h"
#include <string>
#include "SyntaxNode.h"

using std::string;
using namespace Trinity::Codegen;

static void _ValueTypeToAccessorFieldAssignment(NFieldType* type, bool create_optional, string* source)
{
    if (create_optional)
    {
        source->append("\
                targetPtr = this.ResizeFunction(targetPtr, 0, ").append(Codegen::GetString(type->type_size())).append(");");
    }
    source->append("\
                *(").append(GetNonNullableValueTypeString(type)).append("*)targetPtr = value;");
}

static void _FixedLengthAccessorFieldAssignment(NFieldType* type, string accessor_field_name, bool create_optional, string* source)
{
    string fieldLength = Codegen::GetString(type->type_size());
    if (!create_optional)
    {
        source->append("\
                Memory.Copy(value.m_ptr, targetPtr, " + fieldLength + "); ");
    }
    else
    {
        source->append(R":(
                int offset = (int)(targetPtr - m_ptr);
                int length = ):" + fieldLength + R":(;
                if (value.m_cellId != this.m_cellId)
                {
                    this.m_ptr = this.ResizeFunction(this.m_ptr, offset, length);
                    Memory.Copy(value.m_ptr, this.m_ptr + offset, length);
                }
                else
                {
                    byte[] tmpcell = new byte[length];
                    fixed (byte* tmpcellptr = tmpcell)
                    {
                        Memory.Copy(value.m_ptr, tmpcellptr, length);
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, length);
                        Memory.Copy(tmpcellptr, this.m_ptr + offset, length);
                    }
                }
):");
    }
}

static void _StructAccessorFieldAssignment(NFieldType* type, string accessor_field_name, bool create_optional, string* source, ModuleContext* context)
{
    bool isfixed = type->layoutType == LT_FIXED;
    string ret = R"::(
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;)::";

    if (!create_optional)
    {
        Modules::PushPointerThroughFieldType(type, context);
        ret += R"::(
                int oldlength = (int)(targetPtr - oldtargetPtr);)::";
    }
    else
    {
        ret += R"::(
                int oldlength = 0;)::";
    }

    ret += R"::(
                targetPtr = value.m_ptr;)::";
    Modules::PushPointerThroughFieldType(type, context);
    ret += R"::(
                int newlength = (int)(targetPtr - value.m_ptr);)::";
    if (isfixed)
    {
        ret += R"::(
                Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);)::";
    }
    else
    {
        ret += R"::(
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                })::";
    }
    source->append(ret);
}

static void _LengthPrefixedAccessorFieldAssignment(NFieldType* type, string accessor_field_name, bool create_optional, string* source)
{
    string ret;
    ret += R"::(
                int length = *(int*)(value.m_ptr - 4);)::";
    string resize_len;
                

    if (!create_optional)
    {
        ret += R"::(
                int oldlength = *(int*)targetPtr;)::";
        resize_len = "length - oldlength";
    }
    else
    {
        resize_len = "length + sizeof(int)";
    }

    ret += R"::(
                if (value.m_cellId != )::" + accessor_field_name + R"::(.m_cellId)
                {
                    //if not in the same Cell
                    )::" + accessor_field_name + ".m_ptr = " + accessor_field_name + ".ResizeFunction(targetPtr, 0, " + resize_len + R"::();
                    Memory.Copy(value.m_ptr - 4, )::" + accessor_field_name + R"::(.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        )::" + accessor_field_name + ".m_ptr = " + accessor_field_name + ".ResizeFunction(targetPtr, 0, " + resize_len + R"::();
                        Memory.Copy(tmpcellptr, )::" + accessor_field_name + R"::(.m_ptr, length + 4);
                    }
                }
)::";

    source->append(ret);
}

namespace Trinity
{
    namespace Codegen
    {
        namespace Modules
        {
            /**
             * Generates accessor to accessor-field assignment code.
             * When this module is called, the caller should guarantee that 'targetPtr'
             * points to the location of the field to be assigned. Also, if an accessor
             * is needed for the field, the m_ptr field of the accessor should point
             * to targetPtr, and m_cellId should be properly set.
             * Arguments:
             * 0. accessor field name
             * 1. "FieldDoesNotExist" or "FieldExists" -> determines whether
             *    we create an optional field.
             */
            string* AccessorToAccessorFieldAssignment(NFieldType* type, ModuleContext* context)
            {
                string* source          = new string();
                string  accessor_name   = context->m_arguments[0];
                bool    create_optional = (context->m_arguments[1] == "FieldDoesNotExist");

                if (!data_type_need_accessor(type))
                {
                    _ValueTypeToAccessorFieldAssignment(type, create_optional, source);
                }
                else if (type->layoutType == LT_FIXED)
                {
                    _FixedLengthAccessorFieldAssignment(type, accessor_name, create_optional, source);
                }
                else if (data_type_is_length_prefixed(type))
                {
                    _LengthPrefixedAccessorFieldAssignment(type, accessor_name, create_optional, source);
                }
                else if (type->is_struct())
                {
                    _StructAccessorFieldAssignment(type, accessor_name, create_optional, source, context);
                }
                else
                {
                    error(type, "AccessorToAccessorFieldAssignment: could not process type" + Codegen::GetString(type));
                }

                return source;
            }
        }
    }
}