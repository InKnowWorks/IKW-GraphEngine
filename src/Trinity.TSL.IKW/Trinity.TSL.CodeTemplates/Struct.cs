﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Security;

using Trinity;
using Trinity.Storage;
using Trinity.Utilities;
using Trinity.TSL.Lib;
using Trinity.Network;
using Trinity.Network.Sockets;
using Trinity.Network.Messaging;
using Trinity.TSL;
using System.Text.RegularExpressions;
using Trinity.Core.Lib;

/*MAP_VAR("t_Namespace", "Trinity::Codegen::GetNamespace()")*/
namespace t_Namespace
{
    [TARGET("NStruct")]
    [STRUCT]
    //It is possible to re-map variables on the fly.
    [MAP_LIST("t_field", "node->fieldList")]
    [MAP_VAR("t_field", "")]
    [MAP_VAR("t_field_name", "name")]
    [MAP_VAR("t_field_type", "fieldType")]
    [MAP_VAR("t_data_type", "Trinity::Codegen::GetNonNullableValueTypeString($$->fieldType)", MemberOf = "t_field")]
    [MAP_VAR("t_struct_name", "node->name")]
    [META_VAR("bool", "struct_nonempty", "node->fieldList->size() > 0")]
    [META_VAR("bool", "struct_fixed", "node->getLayoutType() == LT_FIXED")]
    /// <summary>
    /// A .NET runtime object representation of t_struct_name defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial class t_struct_name : __meta
    {
        // Only generate constructor when it contains fields
        [IF("%struct_nonempty")]
        ///<summary>
        ///Initializes a new instance of t_struct_name with the specified parameters.
        ///</summary>
        public t_struct_name(/*FOREACH(",")*/t_field_type t_field_name = default(t_field_type)/*END*/)
        {
            FOREACH();
            this.t_field_name = t_field_name;
            END();
        }

        [END]

        [MUTE]
        //Mocking ctor
        public t_struct_name(t_field_type t_field_name = null, t_field_type t_field_name1 = default(t_field_type)) : this(t_field_name)
        {
            throw new NotImplementedException();
        }
        [MUTE_END]

        public static bool operator ==(t_struct_name a, t_struct_name b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            IF("%struct_nonempty");
            // Return true if the fields match:
            return
                /*FOREACH("&&")*/
                (a.t_field_name == b.t_field_name)
                /*END*/
                ;
            ELSE();
            return true;
            END();
        }

        public static bool operator !=(t_struct_name a, t_struct_name b)
        {
            return !(a == b);
        }

        [FOREACH]
        public t_field_type t_field_name;

        [END]

        /// <summary>
        /// Converts the string representation of a t_struct_name to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(t_struct_name) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out t_struct_name value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<t_struct_name>(input);
                return true;
            }
            catch { value = default(t_struct_name); return false; }
        }

        public static t_struct_name Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<t_struct_name>(input);
        }


        /// <summary>
        /// Serializes this object to a Json string.
        /// </summary>
        /// <returns>The Json string serialized.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }

    /// <summary>
    /// Provides in-place operations of t_struct_name defined in TSL.
    /// </summary>
    public unsafe partial class t_struct_name_Accessor : __meta, IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;

        internal unsafe t_struct_name_Accessor(byte* _CellPtr
            /*IF("!%struct_fixed")*/
            , ResizeFunctionDelegate func
            /*END*/)
        {
            m_ptr = _CellPtr;
            IF("!%struct_fixed");
            ResizeFunction = func;
            ELSE();
            ResizeFunction = (a,b,c) => { return Throw.invalid_resize_on_fixed_struct(); };
            END();

            FOREACH();
            USE_LIST("t_field");
            MODULE_CALL("StructFieldAccessorInitialization", "$t_field");
            END();
        }

        [MODULE_CALL("OptionalFields", "node")]

        ///<summary>
        ///Copies the struct content into a byte array.
        ///</summary>
        public byte[] ToByteArray()
        {
            byte* targetPtr = m_ptr;
            MODULE_CALL("PushPointerThroughStruct", "node");
            int size = (int)(targetPtr - m_ptr);
            byte[] ret = new byte[size];
            Memory.Copy(m_ptr, 0, ret, 0, size);
            return ret;
        }

        #region IAccessor
        public unsafe byte* GetUnderlyingBufferPointer()
        {
            return m_ptr;
        }

        public unsafe int GetBufferLength()
        {
            byte* targetPtr = m_ptr;

            MODULE_CALL("PushPointerThroughStruct", "node");

            int size = (int)(targetPtr - m_ptr);
            return size;
        }

        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion

        [MODULE_CALL("AccessorFieldsDefinition", "node")]

        public static unsafe implicit operator t_struct_name(t_struct_name_Accessor accessor)
        {
            FOREACH();
            IF("$t_field->is_optional()");
            t_field_type _t_field_name = default(t_field_type);
            if (accessor.Contains_t_field_name)
            {
                IF("$t_field_type->is_value_type()");
                _t_field_name = (t_data_type)accessor.t_field_name;
                ELSE();
                _t_field_name = accessor.t_field_name;
                END();
            }
            END();
            END();

            return new t_struct_name(
                /*FOREACH(",")*/
                    /*IF("$t_field->is_optional()")*/
                        _t_field_name /*MUTE*/ , /*MUTE_END*/
                    /*ELSE*/
                        accessor.t_field_name
                    /*END*/
                /*END*/
                );
        }

        [MODULE_CALL("StructAccessorReverseImplicitOperator", "node")]

        [MODULE_CALL("StructAccessorEqualOperator", "node")]

        /// <summary>
        /// Serializes this object to a Json string.
        /// </summary>
        /// <returns>The Json string serialized.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }

        [MUTE]
        public bool Contains_t_field_name { get; private set; }
        private t_field_type t_field_name;
        /*MUTE_END*/
    }
}
