﻿/*MUTE*/
using System;
using System.Collections;
using System.Collections.Generic;
using Trinity.Core.Lib;
using Trinity.TSL;
using Trinity.TSL.Lib;
/*MUTE_END*/

/*MAP_VAR("t_Namespace", "Trinity::Codegen::GetNamespace()")*/
namespace t_Namespace
{
    [TARGET("NFieldType")]
    [MAP_VAR("t_list_accessor", "data_type_get_accessor_name(node)")]
    [MAP_VAR("t_list", "node")]
    [MAP_VAR("t_accessor_type", "data_type_get_accessor_name(node->listElementType)")]
    [MAP_VAR("t_data_type", "node->listElementType")]
    [MAP_VAR("t_data_type_array_element_type", "node->listElementType->arrayInfo.arrayElement")]
    [META_VAR("int", "element_len", "node->listElementType->type_size()")]
    [META_VAR("bool", "element_fixed", "(%element_len > -1)")]
    [META_VAR("bool", "element_need_accessor", "data_type_need_accessor(node->listElementType)")]
    [MAP_VAR("t_int", "%element_len")]

    public unsafe class t_list_accessor : __meta, IEnumerable<t_accessor_type>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;

        internal t_list_accessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;

            MODULE_CALL("ListElementAccessorInitialization", "$t_data_type");
        }

        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }

        [IF("%element_need_accessor")]
        t_accessor_type elementAccessor;
        [END]

        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                IF("%element_fixed");
                return length / t_int;
                ELSE();
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                    ++ret;
                }
                return ret;
                END();
            }
        }

        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe t_accessor_type this[int index]
        {
            get
            {
                IF("!%element_need_accessor");
                return *(t_accessor_type*)(m_ptr + index * t_int);
                ELSE();
                {
                    IF("%element_fixed");
                    elementAccessor.m_ptr = (this.m_ptr + index * t_int);
                    ELSE();
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                        }
                        IF("data_type_is_length_prefixed(node->listElementType)");
                        elementAccessor.m_ptr = targetPtr + 4;
                        ELSE();
                        elementAccessor.m_ptr = targetPtr;
                        END();
                    }
                    END();
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                END();
            }
            set
            {
                IF("!%element_need_accessor");
                *(t_accessor_type*)(m_ptr + index * t_int) = value;
                ELSE();
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    IF("%element_fixed");
                    targetPtr += (index * t_int);
                    ELSE();
                    while (index-- > 0)
                    {
                        MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                    }
                    END();
                    MODULE_CALL("AccessorToAccessorFieldAssignment", "$t_data_type", "\"elementAccessor\"", "\"FieldExists\"");
                }
                END();
            }
        }

        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }

        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<t_accessor_type> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            IF("%element_need_accessor");
            elementAccessor.m_cellId = this.m_cellId;
            END();
            while (targetPtr < endPtr)
            {
                IF("!%element_need_accessor");
                {
                    action(*(t_accessor_type*)targetPtr);
                    targetPtr += t_int;
                }
                ELIF("%element_fixed");
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    targetPtr += t_int;
                }
                ELIF("data_type_is_length_prefixed(node->listElementType)");
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor);
                    MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                }
                ELSE();
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                }
                END();
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<t_accessor_type, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                IF("!%element_need_accessor");
                {
                    action(*(t_accessor_type*)targetPtr, index);
                    targetPtr += t_int;
                }
                ELIF("%element_fixed");
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    targetPtr += t_int;
                }
                ELIF("data_type_is_length_prefixed(node->listElementType)");
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor, index);
                    MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                }
                ELSE();
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                }
                END();
            }
        }

        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            t_list_accessor target;
            internal _iterator(t_list_accessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal t_accessor_type current()
            {
                IF("!%element_need_accessor");
                {
                    return *(t_accessor_type*)targetPtr;
                }
                ELIF("%element_fixed");
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return (target.elementAccessor);
                }
                ELIF("data_type_is_length_prefixed(node->listElementType)");
                {
                    target.elementAccessor.m_ptr = targetPtr + 4;
                    return target.elementAccessor;
                }
                ELSE();
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                END();
            }
            internal void move_next()
            {
                IF("%element_fixed");
                {
                    targetPtr += t_int;
                }
                ELSE(); // dynamic
                {
                    MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                }
                END();
            }
        }
        public IEnumerator<t_accessor_type> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(t_data_type element)
        {
            byte* targetPtr = null;
            {
                MODULE_CALL("PushPointerFromVariable", "$t_data_type", "\"element\"", "\"push\"");
            }

            // TODO AppendCodeForContainer IAccessor code reuse
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);

            MODULE_CALL("PushPointerFromVariable", "$t_data_type", "\"element\"", "\"assign\"");
        }

        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, t_data_type element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                MODULE_CALL("PushPointerFromVariable", "$t_data_type", "\"element\"", "\"push\"");
            }
            int size = (int)targetPtr;

            targetPtr = m_ptr;
            IF("%element_fixed");
            targetPtr += index * t_int;
            ELSE();
            for (int i = 0; i < index; i++)
            {
                MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
            }
            END();
            int offset = (int)(targetPtr - m_ptr);
            // InsertAndRemoveAtCodeForContainer TODO IAccessor reuse
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);

            targetPtr = this.m_ptr + offset;
            MODULE_CALL("PushPointerFromVariable", "$t_data_type", "\"element\"", "\"assign\"");
        }

        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(t_data_type element, Comparison<t_accessor_type> comparison)
        {
            byte* targetPtr = null;
            {
                MODULE_CALL("PushPointerFromVariable", "$t_data_type", "\"element\"", "\"push\"");
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {

                IF("!%element_need_accessor");
                {
                    if (comparison(*(t_accessor_type*)targetPtr, element) <= 0)
                    {
                        targetPtr += t_int;
                    }
                    else
                    {
                        break;
                    }
                }
                ELIF("%element_fixed");
                {
                    elementAccessor.m_ptr = targetPtr;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        targetPtr += t_int;
                    }
                    else
                    {
                        break;
                    }
                }
                ELIF("data_type_is_length_prefixed(node->listElementType)");
                ELIF("node->listElementType->is_struct()");
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                    }
                    else
                    {
                        break;
                    }
                }
                ELSE();
                {
                    elementAccessor.m_ptr = targetPtr;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
                    }
                    else
                    {
                        break;
                    }
                }
                END();
            }

            int offset = (int)(targetPtr - m_ptr);
            // InsertAndRemoveAtCodeForContainer TODO IAccessor reuse
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);

            targetPtr = this.m_ptr + offset;
            MODULE_CALL("PushPointerFromVariable", "$t_data_type", "\"element\"", "\"assign\"");
        }

        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
            // InsertAndRemoveAtCodeForContainer TODO IAccessor reuse
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(t_list collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            t_list_accessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(t_list_accessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }

        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(t_accessor_type item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }

        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<t_accessor_type> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }

        [IF("!$t_data_type->is_array()")]
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(t_data_type[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }

        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(t_data_type[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }

        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, t_data_type[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
        [ELSE]  // if t_data_type is array
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(t_data_type_array_element_type[]/*META_OUTPUT("Trinity::Codegen::data_type_get_array_size_specifier_string($t_data_type)")*/ array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = (t_data_type)((t_data_type)x).Clone());
        }

        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(t_data_type_array_element_type[]/*META_OUTPUT("Trinity::Codegen::data_type_get_array_size_specifier_string($t_data_type)")*/ array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = (t_data_type)((t_data_type)x).Clone());
        }

        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, t_data_type_array_element_type[]/*META_OUTPUT("Trinity::Codegen::data_type_get_array_size_specifier_string($t_data_type)")*/ array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = (t_data_type)((t_data_type)this[i]).Clone();
                ++j;
            }
        }
        [END]  // if t_data_type is array

        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, t_list collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            t_list_accessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }

        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                MODULE_CALL("PushPointerThroughFieldType", "$t_data_type");
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }

        public unsafe static implicit operator t_list (t_list_accessor accessor)
        {
            if((object)accessor == null) return null;
            t_list list = new t_list();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        [MODULE_CALL("AccessorReverseImplicitOperator", "node")]

        public static bool operator ==(t_list_accessor a, t_list_accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            // If both are same instance, return true.
            if (a.m_ptr == b.m_ptr) return true;
            // If length not equal, return false.
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }

        public static bool operator !=(t_list_accessor a, t_list_accessor b)
        {
            return !(a == b);
        }
    }
}
