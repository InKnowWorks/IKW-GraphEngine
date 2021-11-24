﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Trinity.Core.Lib;
using Trinity.TSL;
using Trinity.TSL.Lib;

/*MAP_VAR("t_Namespace", "Trinity::Codegen::GetNamespace()")*/
namespace t_Namespace
{
    /// <summary>
    /// Reusable buffer.
    /// </summary>
    [TARGET("NTSL")]
    internal unsafe class BufferAllocator
    {
        [ThreadStatic]
        private static BufferAllocator ts_Buffer   = null;
        private int                    m_bufferLen = 0;
        private byte*                  m_bufferPtr = null;
        private const int              c_maxLength = 1 << 20;

        ~BufferAllocator()
        {
            if (m_bufferPtr != null)
            {
                Memory.free(m_bufferPtr);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe byte* _AllocBuffer(int length)
        {
            bool need_realloc = false;

            if (m_bufferLen < length)
            {
                m_bufferLen = Math.Max(m_bufferLen * 3 / 2, length);
                need_realloc = true;
            }
            // if buffer too big, bounce back to current requested length
            if (m_bufferLen > c_maxLength)
            {
                m_bufferLen = length;
                need_realloc = true;
            }
            if (need_realloc)
            {
                m_bufferPtr = (byte*)Memory.realloc(m_bufferPtr, (ulong)m_bufferLen);
            }
            return m_bufferPtr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte* AllocBuffer(int length)
        {
            if (ts_Buffer == null) { ts_Buffer = new BufferAllocator(); }
            return ts_Buffer._AllocBuffer(length);
        }
    }
}
