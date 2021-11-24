#include "common.h"
#include <string>
#include "SyntaxNode.h"

using std::string;

namespace Trinity
{
    namespace Codegen
    {
        string* 
Cell(
NCell* node)
        {
            string* source = new string();
            
source->append(R"::(using System;
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
using Trinity.Core.Lib;
using Trinity.Storage;
using Trinity.Utilities;
using Trinity.TSL.Lib;
using Trinity.Network;
using Trinity.Network.Sockets;
using Trinity.Network.Messaging;
using Trinity.TSL;
using System.Runtime.CompilerServices;
using Trinity.Storage.Transaction;
using Microsoft.Extensions.ObjectPool;
namespace )::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(
{
    )::");
bool struct_nonempty_1 = node->fieldList->size() > 0;
std::unordered_set<std::string> field_attributes_1;
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
for (size_t iterator_2 = 0; iterator_2 < ((*(node->fieldList))[iterator_1]->attributes)->size();++iterator_2)
{
field_attributes_1.insert(*(*((*(node->fieldList))[iterator_1]->attributes))[iterator_2]->key);
}
}
source->append(R"::(
    /// <summary>
    /// A .NET runtime object representation of )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( defined in TSL.
    /// </summary>
    public partial struct )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( : ICell
    {
        ///<summary>
        ///The id of the cell.
        ///</summary>
        public long CellId;
        ///<summary>
        ///Initializes a new instance of )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( with the specified parameters.
        ///</summary>
        public )::");
source->append(Codegen::GetString(node->name));
source->append(R"::((long cell_id )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(, )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::( )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = default()::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::())::");
}
source->append(R"::()
        {
            )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
            this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(;
            )::");
}
source->append(R"::(
            CellId = cell_id;
        }
        )::");
if (struct_nonempty_1)
{
source->append(R"::(
        ///<summary>
        ///Initializes a new instance of )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( with the specified parameters.
        ///</summary>
        public )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(()::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::( )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::( )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = default()::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::())::");
if (iterator_1 < (node->fieldList)->size() - 1)
source->append(",");
}
source->append(R"::()
        {
            )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
            this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(;
            )::");
}
source->append(R"::(
            CellId = CellIdFactory.NewCellId();
        }
        )::");
}
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
        public )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::( )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(;
        )::");
}
source->append(R"::(
        public static bool operator ==()::");
source->append(Codegen::GetString(node->name));
source->append(R"::( a, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            )::");
if (struct_nonempty_1)
{
source->append(R"::(
            return
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                (a.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( == b.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::()
                )::");
if (iterator_1 < (node->fieldList)->size() - 1)
source->append("&&");
}
source->append(R"::(
                ;
            )::");
}
else
{
source->append(R"::(
            return true;
            )::");
}
source->append(R"::(
        }
        public static bool operator !=()::");
source->append(Codegen::GetString(node->name));
source->append(R"::( a, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( b)
        {
            return !(a == b);
        }
        #region Text processing
        /// <summary>
        /// Converts the string representation of a )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default()::");
source->append(Codegen::GetString(node->name));
source->append(R"::() if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// True if input was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string input, out )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(>(input);
                return true;
            }
            catch { value = default()::");
source->append(Codegen::GetString(node->name));
source->append(R"::(); return false; }
        }
        public static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(>(input);
        }
        ///<summary>Converts a )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to its string representation, in JSON format.</summary>
        ///<returns>A string representation of the )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
            ")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::("
            )::");
if (iterator_1 < (node->fieldList)->size() - 1)
source->append(",");
}
source->append(R"::(
            );
        internal static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
if ((*(node->fieldList))[iterator_1]->fieldType->is_value_type())
{
source->append(R"::(
            ")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::("
            ,)::");
}
}
source->append(R"::(
        };
        #endregion
        #region ICell implementation
        /// <summary>
        /// Get the field of the specified name in the cell.
        /// </summary>
        /// <typeparam name="T">
        /// The desired type that the field is supposed 
        /// to be interpreted as. Automatic type casting 
        /// will be attempted if the desired type is not 
        /// implicitly convertible from the type of the field.
        /// </typeparam>
        /// <param name="fieldName">The name of the target field.</param>
        /// <returns>The value of the field.</returns>
        public T GetField<T>(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                return TypeConverter<T>.ConvertFrom_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType)));
source->append(R"::((this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::();
                )::");
}
source->append(R"::(
            }
            /* Should not reach here */
            throw new Exception("Internal error T5005");
        }
        /// <summary>
        /// Set the value of the target field.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value.
        /// </typeparam>
        /// <param name="fieldName">The name of the target field.</param>
        /// <param name="value">
        /// The value of the field. Automatic type casting 
        /// will be attempted if the desired type is not 
        /// implicitly convertible from the type of the field.
        /// </param>
        public void SetField<T>(string fieldName, T value)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = TypeConverter<T>.ConvertTo_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType)));
source->append(R"::((value);
                break;
                )::");
}
source->append(R"::(
                default:
                Throw.data_type_incompatible_with_field(typeof(T).ToString());
                break;
            }
        }
        /// <summary>
        /// Tells if a field with the given name exists in the current cell.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The existence of the field.</returns>
        public bool ContainsField(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                )::");
if ((*(node->fieldList))[iterator_1]->fieldType->is_optional())
{
source->append(R"::(
                return this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( != null;
                )::");
}
else
{
source->append(R"::(
                return true;
                )::");
}
}
source->append(R"::(
                default:
                return false;
            }
        }
        /// <summary>
        /// Append <paramref name="value"/> to the target field. Note that if the target field
        /// is not appendable(string or list), calling this method is equivalent to <see cref=")::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.GenericCellAccessor.SetField(string, T)"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value.
        /// </typeparam>
        /// <param name="fieldName">The name of the target field.</param>
        /// <param name="value">The value to be appended. 
        /// If the value is incompatible with the element 
        /// type of the field, automatic type casting will be attempted.
        /// </param>
        public void AppendToField<T>(string fieldName, T value)
        {
            if (AppendToFieldRerouteSet.Contains(fieldName))
            {
                SetField(fieldName, value);
                return;
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
if ((*(node->fieldList))[iterator_1]->fieldType->is_string() || (*(node->fieldList))[iterator_1]->fieldType->is_list())
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                )::");
if ((*(node->fieldList))[iterator_1]->fieldType->is_string())
{
source->append(R"::(
                {
                    if (this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( == null)
                        this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = TypeConverter<T>.ConvertTo_string(value);
                    else
                        this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( += TypeConverter<T>.ConvertTo_string(value);
                }
                )::");
}
else if ((*(node->fieldList))[iterator_1]->fieldType->is_list())
{
source->append(R"::(
                {
                    if (this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( == null)
                        this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = new )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::(();
                    switch (TypeConverter<T>.GetConversionActionTo_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType)));
source->append(R"::(())
                    {
                        case TypeConversionAction.TC_ASSIGN:
                        foreach (var element in value as )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::()
                            this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(.Add(element);
                        break;
                        case TypeConversionAction.TC_CONVERTLIST:
                        case TypeConversionAction.TC_ARRAYTOLIST:
                        foreach (var element in TypeConverter<T>.Enumerate_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType->listElementType)));
source->append(R"::((value))
                            this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(.Add(element);
                        break;
                        case TypeConversionAction.TC_WRAPINLIST:
                        case TypeConversionAction.TC_PARSESTRING:
                        this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(.Add(TypeConverter<T>.ConvertTo_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType->listElementType)));
source->append(R"::((value));
                        break;
                        default:
                        Throw.data_type_incompatible_with_list(typeof(T).ToString());
                        break;
                    }
                }
                )::");
}
source->append(R"::(
                break;
                )::");
}
}
source->append(R"::(
                default:
                Throw.target__field_not_list();
                break;
            }
        }
        long ICell.CellId { get { return CellId; } set { CellId = value; } }
        public IEnumerable<KeyValuePair<string, T>> SelectFields<T>(string attributeKey, string attributeValue)
        {
            switch (TypeConverter<T>.type_id)
            {
                )::");
for (size_t iterator_1 = 0; iterator_1 < (Trinity::Codegen::TSLExternalParserDataTypeVector)->size();++iterator_1)
{
bool compatible_1 = false;
for (size_t iterator_2 = 0; iterator_2 < (node->fieldList)->size();++iterator_2)
{
if ((*(Trinity::Codegen::TSLExternalParserDataTypeVector))[iterator_1]->is_convertible_from((*(node->fieldList))[iterator_2]->fieldType))
{
compatible_1 = true;
}
}
if (compatible_1)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                )::");
for (size_t iterator_2 = 0; iterator_2 < (node->fieldList)->size();++iterator_2)
{
if ((*(Trinity::Codegen::TSLExternalParserDataTypeVector))[iterator_1]->is_convertible_from((*(node->fieldList))[iterator_2]->fieldType))
{
source->append(R"::(
                if (StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_descriptor.check_attribute(StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_descriptor.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_2]->name));
source->append(R"::(, attributeKey, attributeValue))
                    )::");
if ((*(node->fieldList))[iterator_2]->is_optional())
{
source->append(R"::(
                    if (this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_2]->name));
source->append(R"::( != null)
                        )::");
}
source->append(R"::(
                        yield return new KeyValuePair<string, T>(")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_2]->name));
source->append(R"::(", TypeConverter<T>.ConvertFrom_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_2]->fieldType)));
source->append(R"::((this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_2]->name));
source->append(R"::());
                )::");
}
}
source->append(R"::(
                break;
                )::");
}
}
source->append(R"::(
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value constructs
        )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
        private IEnumerable<T> _enumerate_from_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(<T>()
        {
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
module_ctx.m_arguments.push_back(Codegen::GetString(/*for accessor:*/"false"));
std::string* module_content = Modules::EnumerateFromFieldModule((*(node->fieldList))[iterator_1], &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
        }
        )::");
}
source->append(R"::(
        private static StringLookupTable s_field_attribute_id_table = new StringLookupTable(
            )::");
int iter_val_1 = 0;
for(const std::string& attr : field_attributes_1){
source->append(R"::(
            ")::");
source->append(Codegen::GetString(attr));
source->append(R"::("
            )::");
++iter_val_1;
if (iter_val_1 < field_attributes_1.size())
{
source->append(R"::(,)::");
}
}
source->append(R"::(
            );
        #endregion
        public IEnumerable<T> EnumerateField<T>(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                return _enumerate_from_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(<T>();
                )::");
}
source->append(R"::(
                default:
                Throw.undefined_field();
                return null;
            }
        }
        public IEnumerable<T> EnumerateValues<T>(string attributeKey, string attributeValue)
        {
            int attr_id;
            if (attributeKey == null)
            {
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                foreach (var val in _enumerate_from_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(<T>())
                    yield return val;
                )::");
}
source->append(R"::(
            }
            else if (-1 != (attr_id = s_field_attribute_id_table.Lookup(attributeKey)))
            {
                switch (attr_id)
                {
                    )::");
int iter_val_2 = 0;
for(const std::string& attr : field_attributes_1){
source->append(R"::(
                    case )::");
source->append(Codegen::GetString(iter_val_2++));
source->append(R"::(:
                    )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                    {
                        )::");
std::string* p_field_attr_value_1 = (*(node->fieldList))[iterator_1]->get_attribute(attr);
if (p_field_attr_value_1 != nullptr)
{
source->append(R"::(
                        {
                            if (attributeValue == null || attributeValue == ")::");
source->append(Codegen::GetString(p_field_attr_value_1));
source->append(R"::(")
                            {
                                foreach (var val in _enumerate_from_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(<T>())
                                    yield return val;
                            }
                        }
                        )::");
}
source->append(R"::(
                    }
                    )::");
}
source->append(R"::(
                    break;
                    )::");
}
source->append(R"::(
                }
            }
            yield break;
        }
        public ICellAccessor Serialize()
        {
            return ()::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor)this;
        }
        #endregion
        #region Other interfaces
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.GetFieldDescriptors();
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.GetFieldAttributes(fieldName);
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.GetAttributeValue(attributeKey);
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.Attributes; }
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            )::");
int field_cnt_1 = 0;
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
if ((*(node->fieldList))[iterator_1]->is_optional())
{
source->append(R"::(
            {
                if (this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( != null)
                    yield return ")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(";
            }
            )::");
}
else
{
source->append(R"::(
            {
                yield return ")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(";
            }
            )::");
++field_cnt_1;
}
}
if (field_cnt_1 == 0)
{
source->append(R"::(
            {
                yield break;
            }
            )::");
}
source->append(R"::(
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(;
            }
        }
        #endregion
    }
    /// <summary>
    /// Provides in-place operations of )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( defined in TSL.
    /// </summary>
    public unsafe class )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor : ICellAccessor
    {
        #region Fields
        internal   long                    m_cellId;
        /// <summary>
        /// A pointer to the underlying raw binary blob. Take caution when accessing data with
        /// the raw pointer, as no boundary checks are employed, and improper operations will cause data corruption and/or system crash.
        /// </summary>
        internal byte*                   m_ptr;
        internal LocalTransactionContext m_tx;
        internal int                     m_cellEntryIndex;
        internal CellAccessOptions       m_options;
        internal bool                    m_IsIterator;
        private  const CellAccessOptions c_WALFlags = CellAccessOptions.StrongLogAhead | CellAccessOptions.WeakLogAhead;
        #endregion
        #region Constructors
        private unsafe )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor()
        {
            )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
std::string* module_content = Modules::CellFieldAccessorInitialization((*(node->fieldList))[iterator_1], &module_ctx);
    source->append(*module_content);
    delete module_content;
}
}
source->append(R"::(
        }
        #endregion
        )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
std::string* module_content = Modules::OptionalFields(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
        #region IAccessor Implementation
        public byte[] ToByteArray()
        {
            byte* targetPtr = m_ptr;
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
std::string* module_content = Modules::PushPointerThroughStruct(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
            int size = (int)(targetPtr - m_ptr);
            byte[] ret = new byte[size];
            Memory.Copy(m_ptr, 0, ret, 0, size);
            return ret;
        }
        public unsafe byte* GetUnderlyingBufferPointer()
        {
            return m_ptr;
        }
        public unsafe int GetBufferLength()
        {
            byte* targetPtr = m_ptr;
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
std::string* module_content = Modules::PushPointerThroughStruct(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        private static byte[] s_default_content = null;
        private static unsafe byte[] construct()::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::( )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::( )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = default()::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::() )::");
if (iterator_1 < (node->fieldList)->size() - 1)
source->append(",");
}
source->append(R"::()
        {
            if (s_default_content != null) return s_default_content;
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
module_ctx.m_arguments.push_back(Codegen::GetString("cell"));
std::string* module_content = Modules::SerializeParametersToBuffer(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
            s_default_content = tmpcell;
            return tmpcell;
        }
        )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
std::string* module_content = Modules::AccessorFieldsDefinition(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
        public static unsafe implicit operator )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(()::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor accessor)
        {
            )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
if ((*(node->fieldList))[iterator_1]->is_optional())
{
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::( _)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = default()::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::();
            if (accessor.Contains_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::()
            {
                )::");
if ((*(node->fieldList))[iterator_1]->fieldType->is_value_type())
{
source->append(R"::(
                _)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = ()::");
source->append(Codegen::GetString(Trinity::Codegen::GetNonNullableValueTypeString((*(node->fieldList))[iterator_1]->fieldType)));
source->append(R"::()accessor.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(;
                )::");
}
else
{
source->append(R"::(
                _)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = accessor.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(;
                )::");
}
source->append(R"::(
            }
            )::");
}
}
source->append(R"::(
            return new )::");
source->append(Codegen::GetString(node->name));
source->append(R"::((accessor.CellId
            )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
            ,
            )::");
if ((*(node->fieldList))[iterator_1]->is_optional())
{
source->append(R"::(
            _)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( )::");
}
else
{
source->append(R"::(
                    accessor.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
}
}
source->append(R"::(
            );
        }
        )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
std::string* module_content = Modules::StructAccessorReverseImplicitOperator(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
std::string* module_content = Modules::StructAccessorEqualOperator(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
        public static bool operator ==()::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor a, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( b)
        {
            )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor bb = b;
            return (a == bb);
        }
        public static bool operator !=()::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor a, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Get the size of the cell content, in bytes.
        /// </summary>
        public int CellSize { get { int size; Global.LocalStorage.LockedGetCellSize(this.CellId, this.m_cellEntryIndex, out size); return size; } }
        #region Internal
        private unsafe byte* _Resize_NonTx(byte* ptr, int ptr_offset, int delta)
        {
            int offset = (int)(ptr - m_ptr) + ptr_offset;
            m_ptr = Global.LocalStorage.ResizeCell((long)CellId, m_cellEntryIndex, offset, delta);
            return m_ptr + (offset - ptr_offset);
        }
        private unsafe byte* _Resize_Tx(byte* ptr, int ptr_offset, int delta)
        {
            int offset = (int)(ptr - m_ptr) + ptr_offset;
            m_ptr = Global.LocalStorage.ResizeCell(m_tx, (long)CellId, m_cellEntryIndex, offset, delta);
            return m_ptr + (offset - ptr_offset);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)::");
source->append(R"::()]
        internal unsafe )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor _Lock(long cellId, CellAccessOptions options)
        {
            ushort cellType;
            this.CellId = cellId;
            this.m_options = options;
            this.ResizeFunction = _Resize_NonTx;
            TrinityErrorCode eResult = Global.LocalStorage.GetLockedCellInfo(cellId, out _, out cellType, out this.m_ptr, out this.m_cellEntryIndex);
            switch (eResult)
            {
                case TrinityErrorCode.E_SUCCESS:
                {
                    if (cellType != (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::()
                    {
                        Global.LocalStorage.ReleaseCellLock(cellId, this.m_cellEntryIndex);
                        _put(this);
                        Throw.wrong_cell_type();
                    }
                    break;
                }
                case TrinityErrorCode.E_CELL_NOT_FOUND:
                {
                    if ((options & CellAccessOptions.ThrowExceptionOnCellNotFound) != 0)
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    else if ((options & CellAccessOptions.CreateNewOnCellNotFound) != 0)
                    {
                        byte[]  defaultContent = construct();
                        int     size           = defaultContent.Length;
                        eResult                = Global.LocalStorage.AddOrUse(cellId, defaultContent, ref size, (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(, out this.m_ptr, out this.m_cellEntryIndex);
                        if (eResult == TrinityErrorCode.E_WRONG_CELL_TYPE)
                        {
                            _put(this);
                            Throw.wrong_cell_type();
                        }
                    }
                    else if ((options & CellAccessOptions.ReturnNullOnCellNotFound) != 0)
                    {
                        _put(this);
                        return null;
                    }
                    else
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    break;
                }
                default:
                _put(this);
                throw new NotImplementedException();
            }
            return this;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor _Lock(long cellId, CellAccessOptions options, LocalTransactionContext tx)
        {
            ushort cellType;
            this.CellId = cellId;
            this.m_options = options;
            this.m_tx = tx;
            this.ResizeFunction = _Resize_Tx;
            TrinityErrorCode eResult = Global.LocalStorage.GetLockedCellInfo(tx, cellId, out _, out cellType, out this.m_ptr, out this.m_cellEntryIndex);
            switch (eResult)
            {
                case TrinityErrorCode.E_SUCCESS:
                {
                    if (cellType != (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::()
                    {
                        Global.LocalStorage.ReleaseCellLock(tx, cellId, this.m_cellEntryIndex);
                        _put(this);
                        Throw.wrong_cell_type();
                    }
                    break;
                }
                case TrinityErrorCode.E_CELL_NOT_FOUND:
                {
                    if ((options & CellAccessOptions.ThrowExceptionOnCellNotFound) != 0)
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    else if ((options & CellAccessOptions.CreateNewOnCellNotFound) != 0)
                    {
                        byte[]  defaultContent = construct();
                        int     size           = defaultContent.Length;
                        eResult                = Global.LocalStorage.AddOrUse(tx, cellId, defaultContent, ref size, (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(, out this.m_ptr, out this.m_cellEntryIndex);
                        if (eResult == TrinityErrorCode.E_WRONG_CELL_TYPE)
                        {
                            _put(this);
                            Throw.wrong_cell_type();
                        }
                    }
                    else if ((options & CellAccessOptions.ReturnNullOnCellNotFound) != 0)
                    {
                        _put(this);
                        return null;
                    }
                    else
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    break;
                }
                default:
                _put(this);
                throw new NotImplementedException();
            }
            return this;
        }
        private class PoolPolicy : IPooledObjectPolicy<)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor>
        {
            public )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor Create()
            {
                return new )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor();
            }
            public bool Return()::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor obj)
            {
                return !obj.m_IsIterator;
            }
        }
        private static DefaultObjectPool<)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor> s_accessor_pool = new DefaultObjectPool<)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor>(new PoolPolicy());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor _get() => s_accessor_pool.Get();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void _put()::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor item) => s_accessor_pool.Return(item);
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options)
        {
            this.CellId      = CellId;
            m_cellEntryIndex = entryIndex;
            m_options        = options;
            m_ptr            = cellPtr;
            m_tx             = null;
            this.ResizeFunction = _Resize_NonTx;
            return this;
        }
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options, LocalTransactionContext tx)
        {
            this.CellId      = CellId;
            m_cellEntryIndex = entryIndex;
            m_options        = options;
            m_ptr            = cellPtr;
            m_tx             = tx;
            this.ResizeFunction = _Resize_Tx;
            return this;
        }
        /// <summary>
        /// For internal use only.
        /// </summary>
        internal static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor AllocIterativeAccessor(CellInfo info, LocalTransactionContext tx)
        {
            )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor accessor = new )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor();
            accessor.m_IsIterator = true;
            if (tx != null) accessor._Setup(info.CellId, info.CellPtr, info.CellEntryIndex, 0, tx);
            else accessor._Setup(info.CellId, info.CellPtr, info.CellEntryIndex, 0);
            return accessor;
        }
        #endregion
        #region Public
        /// <summary>
        /// Dispose the accessor.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// the cell lock will be released.
        /// If write-ahead-log behavior is specified on <see cref=")::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.StorageExtension_)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.Use)::");
source->append(Codegen::GetString(node->name));
source->append(R"::("/>,
        /// the changes will be committed to the write-ahead log.
        /// </summary>
        public void Dispose()
        {
            if (m_cellEntryIndex >= 0)
            {
                if ((m_options & c_WALFlags) != 0)
                {
                    LocalMemoryStorage.CWriteAheadLog(this.CellId, this.m_ptr, this.CellSize, (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(, m_options);
                }
                if (!m_IsIterator)
                {
                    if (m_tx == null) Global.LocalStorage.ReleaseCellLock(CellId, m_cellEntryIndex);
                    else Global.LocalStorage.ReleaseCellLock(m_tx, CellId, m_cellEntryIndex);
                }
            }
            _put(this);
        }
        /// <summary>
        /// Get the cell type id.
        /// </summary>
        /// <returns>A 16-bit unsigned integer representing the cell type id.</returns>
        public ushort GetCellType()
        {
            ushort cellType;
            if (Global.LocalStorage.GetCellType(CellId, out cellType) == TrinityErrorCode.E_CELL_NOT_FOUND)
            {
                Throw.cell_not_found();
            }
            return cellType;
        }
        /// <summary>Converts a )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor to its string representation, in JSON format.</summary>
        /// <returns>A string representation of the )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
            ")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::("
            )::");
if (iterator_1 < (node->fieldList)->size() - 1)
source->append(",");
}
source->append(R"::(
            );
        static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
if ((*(node->fieldList))[iterator_1]->fieldType->is_value_type())
{
source->append(R"::(
            ")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::("
            ,)::");
}
}
source->append(R"::(
        };
        #endregion
        #region ICell implementation
        public T GetField<T>(string fieldName)
        {
            int field_divider_idx = fieldName.IndexOf('.');
            if (-1 != field_divider_idx)
            {
                string field_name_string = fieldName.Substring(0, field_divider_idx);
                switch (FieldLookupTable.Lookup(field_name_string))
                {
                    case -1:
                    Throw.undefined_field();
                    break;
                    )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
if ((*(node->fieldList))[iterator_1]->fieldType->is_struct())
{
source->append(R"::(
                    case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                    return GenericFieldAccessor.GetField<T>(this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(, fieldName, field_divider_idx + 1);
                    )::");
}
}
source->append(R"::(
                    default:
                    Throw.member_access_on_non_struct__field(field_name_string);
                    break;
                }
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                return TypeConverter<T>.ConvertFrom_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType)));
source->append(R"::((this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::();
                )::");
}
source->append(R"::(
            }
            /* Should not reach here */
            throw new Exception("Internal error T5005");
        }
        public void SetField<T>(string fieldName, T value)
        {
            int field_divider_idx = fieldName.IndexOf('.');
            if (-1 != field_divider_idx)
            {
                string field_name_string = fieldName.Substring(0, field_divider_idx);
                switch (FieldLookupTable.Lookup(field_name_string))
                {
                    case -1:
                    Throw.undefined_field();
                    break;
                    )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
if ((*(node->fieldList))[iterator_1]->fieldType->is_struct())
{
source->append(R"::(
                    case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                    GenericFieldAccessor.SetField(this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(, fieldName, field_divider_idx + 1, value);
                    break;
                    )::");
}
}
source->append(R"::(
                    default:
                    Throw.member_access_on_non_struct__field(field_name_string);
                    break;
                }
                return;
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                {
                    )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::( conversion_result = TypeConverter<T>.ConvertTo_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType)));
source->append(R"::((value);
                    )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
module_ctx.m_arguments.push_back(Codegen::GetString("this"));
module_ctx.m_arguments.push_back(Codegen::GetString("conversion_result"));
std::string* module_content = Modules::ValueToAccessorFieldAssignment((*(node->fieldList))[iterator_1], &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
                }
                break;
                )::");
}
source->append(R"::(
            }
        }
        /// <summary>
        /// Tells if a field with the given name exists in the current cell.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The existence of the field.</returns>
        public bool ContainsField(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                )::");
if ((*(node->fieldList))[iterator_1]->fieldType->is_optional())
{
source->append(R"::(
                return this.Contains_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(;
                )::");
}
else
{
source->append(R"::(
                return true;
                )::");
}
}
source->append(R"::(
                default:
                return false;
            }
        }
        public void AppendToField<T>(string fieldName, T value)
        {
            if (AppendToFieldRerouteSet.Contains(fieldName))
            {
                SetField(fieldName, value);
                return;
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
if ((*(node->fieldList))[iterator_1]->fieldType->is_string() || (*(node->fieldList))[iterator_1]->fieldType->is_list())
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                )::");
if ((*(node->fieldList))[iterator_1]->fieldType->is_string())
{
source->append(R"::(
                {
                    )::");
if ((*(node->fieldList))[iterator_1]->fieldType->is_optional())
{
source->append(R"::(
                    if (!this.Contains_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::()
                        this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = "";
                    )::");
}
source->append(R"::(
                    this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( += TypeConverter<T>.ConvertTo_string(value);
                }
                )::");
}
else if ((*(node->fieldList))[iterator_1]->fieldType->is_list())
{
source->append(R"::(
                {
                    )::");
if ((*(node->fieldList))[iterator_1]->fieldType->is_optional())
{
source->append(R"::(
                    if (!this.Contains_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::()
                        this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = new )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::(();
                    )::");
}
source->append(R"::(
                    switch (TypeConverter<T>.GetConversionActionTo_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType)));
source->append(R"::(())
                    {
                        case TypeConversionAction.TC_ASSIGN:
                        foreach (var element in value as )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::()
                            this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(.Add(element);
                        break;
                        case TypeConversionAction.TC_CONVERTLIST:
                        case TypeConversionAction.TC_ARRAYTOLIST:
                        foreach (var element in TypeConverter<T>.Enumerate_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType->listElementType)));
source->append(R"::((value))
                            this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(.Add(element);
                        break;
                        case TypeConversionAction.TC_WRAPINLIST:
                        case TypeConversionAction.TC_PARSESTRING:
                        this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(.Add(TypeConverter<T>.ConvertTo_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_1]->fieldType->listElementType)));
source->append(R"::((value));
                        break;
                        default:
                        Throw.data_type_incompatible_with_list(typeof(T).ToString());
                        break;
                    }
                }
                )::");
}
source->append(R"::(
                break;
                )::");
}
}
source->append(R"::(
                default:
                Throw.target__field_not_list();
                break;
            }
        }
        public long CellId { get { return m_cellId; } set { m_cellId = value; } }
        IEnumerable<KeyValuePair<string, T>> ICell.SelectFields<T>(string attributeKey, string attributeValue)
        {
            switch (TypeConverter<T>.type_id)
            {
                )::");
for (size_t iterator_1 = 0; iterator_1 < (Trinity::Codegen::TSLExternalParserDataTypeVector)->size();++iterator_1)
{
bool compatible_2 = false;
for (size_t iterator_2 = 0; iterator_2 < (node->fieldList)->size();++iterator_2)
{
if ((*(Trinity::Codegen::TSLExternalParserDataTypeVector))[iterator_1]->is_convertible_from((*(node->fieldList))[iterator_2]->fieldType))
{
compatible_2 = true;
}
}
if (compatible_2)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                )::");
for (size_t iterator_2 = 0; iterator_2 < (node->fieldList)->size();++iterator_2)
{
if ((*(Trinity::Codegen::TSLExternalParserDataTypeVector))[iterator_1]->is_convertible_from((*(node->fieldList))[iterator_2]->fieldType))
{
source->append(R"::(
                if (StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_descriptor.check_attribute(StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_descriptor.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_2]->name));
source->append(R"::(, attributeKey, attributeValue))
                    )::");
if ((*(node->fieldList))[iterator_2]->is_optional())
{
source->append(R"::(
                    if (Contains_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_2]->name));
source->append(R"::()
                        )::");
}
source->append(R"::(
                        yield return new KeyValuePair<string, T>(")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_2]->name));
source->append(R"::(", TypeConverter<T>.ConvertFrom_)::");
source->append(Codegen::GetString(Trinity::Codegen::GetDataTypeDisplayString((*(node->fieldList))[iterator_2]->fieldType)));
source->append(R"::((this.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_2]->name));
source->append(R"::());
                )::");
}
}
source->append(R"::(
                break;
                )::");
}
}
source->append(R"::(
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value methods
        )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
        private IEnumerable<T> _enumerate_from_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(<T>()
        {
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
module_ctx.m_arguments.push_back(Codegen::GetString(/*for accessor:*/"true"));
std::string* module_content = Modules::EnumerateFromFieldModule((*(node->fieldList))[iterator_1], &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
        }
        )::");
}
source->append(R"::(
        private static StringLookupTable s_field_attribute_id_table = new StringLookupTable(
            )::");
int iter_val_3 = 0;
for(const std::string& attr : field_attributes_1){
source->append(R"::(
            ")::");
source->append(Codegen::GetString(attr));
source->append(R"::("
            )::");
++iter_val_3;
if (iter_val_3 < field_attributes_1.size())
{
source->append(R"::(,)::");
}
}
source->append(R"::(
            );
        #endregion
        public IEnumerable<T> EnumerateField<T>(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                case )::");
source->append(Codegen::GetString(iterator_1));
source->append(R"::(:
                return _enumerate_from_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(<T>();
                )::");
}
source->append(R"::(
                default:
                Throw.undefined_field();
                return null;
            }
        }
        IEnumerable<T> ICell.EnumerateValues<T>(string attributeKey, string attributeValue)
        {
            int attr_id;
            if (attributeKey == null)
            {
                )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                foreach (var val in _enumerate_from_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(<T>())
                    yield return val;
                )::");
}
source->append(R"::(
            }
            else if (-1 != (attr_id = s_field_attribute_id_table.Lookup(attributeKey)))
            {
                switch (attr_id)
                {
                    )::");
int iter_val_4 = 0;
for(const std::string& attr : field_attributes_1){
source->append(R"::(
                    case )::");
source->append(Codegen::GetString(iter_val_4++));
source->append(R"::(:
                    )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(
                    {
                        )::");
std::string* p_field_attr_value_2 = (*(node->fieldList))[iterator_1]->get_attribute(attr);
if (p_field_attr_value_2 != nullptr)
{
source->append(R"::(
                        {
                            if (attributeValue == null || attributeValue == ")::");
source->append(Codegen::GetString(p_field_attr_value_2));
source->append(R"::(")
                            {
                                foreach (var val in _enumerate_from_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(<T>())
                                    yield return val;
                            }
                        }
                        )::");
}
source->append(R"::(
                    }
                    )::");
}
source->append(R"::(
                    break;
                    )::");
}
source->append(R"::(
                }
            }
            yield break;
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            )::");
int field_cnt_2 = 0;
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
if ((*(node->fieldList))[iterator_1]->is_optional())
{
source->append(R"::(
            {
                if (Contains_)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::()
                    yield return ")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(";
            }
            )::");
}
else
{
source->append(R"::(
            {
                yield return ")::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::(";
            }
            )::");
++field_cnt_2;
}
}
if (field_cnt_2 == 0)
{
source->append(R"::(
            {
                yield break;
            }
            )::");
}
source->append(R"::(
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.GetFieldAttributes(fieldName);
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.GetFieldDescriptors();
        }
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.Attributes; }
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.GetAttributeValue(attributeKey);
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(;
            }
        }
        public ICellAccessor Serialize()
        {
            return this;
        }
        #endregion
        public ICell Deserialize()
        {
            return ()::");
source->append(Codegen::GetString(node->name));
source->append(R"::()this;
        }
    }
    ///<summary>
    ///Provides interfaces for accessing )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( cells
    ///on <see cref="Trinity.Storage.LocalMemorySotrage"/>.
    static public class StorageExtension_)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(
    {
        #region IKeyValueStore non logging
        /// <summary>
        /// Adds a new cell of type )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this IKeyValueStore storage, long cellId)::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(, )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::( )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = default()::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::())::");
}
source->append(R"::()
        {
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
module_ctx.m_arguments.push_back(Codegen::GetString("cell"));
std::string* module_content = Modules::SerializeParametersToBuffer(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
            return storage.SaveCell(cellId, tmpcell, (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::() == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this IKeyValueStore storage, long cellId, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( cellContent)
        {
            return Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((storage, cellId )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::( , cellContent.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( )::");
}
source->append(R"::();
        }
        /// <summary>
        /// Adds a new cell of type )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this IKeyValueStore storage, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( cellContent)
        {
            return Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((storage, cellContent.CellId )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::( , cellContent.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( )::");
}
source->append(R"::();
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// </summary>
        public unsafe static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( Load)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this IKeyValueStore storage, long cellId)
        {
            if (TrinityErrorCode.E_SUCCESS == storage.LoadCell(cellId, out var buff))
            {
                fixed (byte* p = buff)
                {
                    return )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor._get()._Setup(cellId, p, -1, 0);
                }
            }
            else
            {
                Throw.cell_not_found();
                throw new Exception();
            }
        }
        #endregion
        #region LocalMemoryStorage Non-Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref=")::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::("/> instance.</returns>
        public unsafe static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor Use)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, long cellId, CellAccessOptions options)
        {
            return )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor._get()._Lock(cellId, options);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".)::");
source->append(Codegen::GetString(node->name));
source->append(R"::("/> instance.</returns>
        public unsafe static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor Use)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            return )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound);
        }
        #endregion
        #region LocalStorage Non-Tx logging
        /// <summary>
        /// Adds a new cell of type )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId)::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(, )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::( )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = default()::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::())::");
}
source->append(R"::()
        {
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
module_ctx.m_arguments.push_back(Codegen::GetString("cell"));
std::string* module_content = Modules::SerializeParametersToBuffer(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
            return storage.SaveCell(options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::() == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( cellContent)
        {
            return Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((storage, options, cellId )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::( , cellContent.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( )::");
}
source->append(R"::();
        }
        /// <summary>
        /// Adds a new cell of type )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( cellContent)
        {
            return Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((storage, options, cellContent.CellId )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::( , cellContent.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( )::");
}
source->append(R"::();
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( Load)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            using (var cell = )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound))
            {
                return cell;
            }
        }
        #endregion
        #region LocalMemoryStorage Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref=")::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::("/> instance.</returns>
        public unsafe static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor Use)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId, CellAccessOptions options)
        {
            return )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor._get()._Lock(cellId, options, tx);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".)::");
source->append(Codegen::GetString(node->name));
source->append(R"::("/> instance.</returns>
        public unsafe static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor Use)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            return )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx);
        }
        #endregion
        #region LocalStorage Tx logging
        /// <summary>
        /// Adds a new cell of type )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId)::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::(, )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::( )::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( = default()::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->fieldType));
source->append(R"::())::");
}
source->append(R"::()
        {
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = 0;
module_ctx.m_arguments.push_back(Codegen::GetString("cell"));
std::string* module_content = Modules::SerializeParametersToBuffer(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
            return storage.SaveCell(tx, options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::() == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( cellContent)
        {
            return Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((storage, tx, options, cellId )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::( , cellContent.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( )::");
}
source->append(R"::();
        }
        /// <summary>
        /// Adds a new cell of type )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( cellContent)
        {
            return Save)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((storage, tx, options, cellContent.CellId )::");
for (size_t iterator_1 = 0; iterator_1 < (node->fieldList)->size();++iterator_1)
{
source->append(R"::( , cellContent.)::");
source->append(Codegen::GetString((*(node->fieldList))[iterator_1]->name));
source->append(R"::( )::");
}
source->append(R"::();
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static )::");
source->append(Codegen::GetString(node->name));
source->append(R"::( Load)::");
source->append(Codegen::GetString(node->name));
source->append(R"::((this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            using (var cell = )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx))
            {
                return cell;
            }
        }
        #endregion
    }
}
)::");

            return source;
        }
    }
}
