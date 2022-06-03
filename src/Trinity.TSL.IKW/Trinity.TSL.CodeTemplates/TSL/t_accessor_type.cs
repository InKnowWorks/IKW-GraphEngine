﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.TSL
{
    /// <summary>
    /// Mocking accessors. We make this mock a POD so that pointers apply.
    /// </summary>
    public partial struct t_accessor_type
    {
        public unsafe t_accessor_type(byte* cellPtr) : this()
        {
            m_ptr=cellPtr;
        }

        internal t_field_type t_field_name { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public unsafe byte* m_ptr { get; internal set; }
        public long m_cellId { get{throw new NotImplementedException(); } internal set{throw new NotImplementedException(); } }

        public static bool operator ==(t_accessor_type a, int b)
        {
            throw new Exception();
        }

        public static bool operator !=(t_accessor_type a, int b)
        {
            throw new Exception();
        }

        public static implicit operator string(t_accessor_type x)
        {
            return "";
        }

        public static implicit operator t_data_type(t_accessor_type x)
        {
            throw new NotImplementedException();
        }

        public static implicit operator t_accessor_type(BitArray x)
        {
            throw new NotImplementedException();
        }

        internal void Remove_t_field_name()
        {
            throw new NotImplementedException();
        }

        public static implicit operator t_accessor_type(DateTime x)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public string this[int index]
        {
            get
            {
                return "";
            }
            set
            {

            }
        }

        internal void Add(string p)
        {
            throw new NotImplementedException();
        }

        internal static string Parse(string p)
        {
            throw new NotImplementedException();
        }

        internal void Add(t_Namespace.t_data_type_list_element_type element)
        {
            throw new NotImplementedException();
        }

        internal int GetLength(uint p)
        {
            throw new NotImplementedException();
        }
    }
}
