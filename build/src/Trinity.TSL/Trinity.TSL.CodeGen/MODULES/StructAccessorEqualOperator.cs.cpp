#include "common.h"
#include <string>
#include "SyntaxNode.h"

using std::string;

namespace Trinity
{
    namespace Codegen
    {
        namespace Modules
        {
            string* 
StructAccessorEqualOperator(
NStructBase* node, ModuleContext* context)
            {
                string* source = new string();
                
source->append(R"::(
        public static bool operator ==()::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor a, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = context->m_stack_depth + 1;
std::string* module_content = Modules::PushPointerThroughStruct(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            )::");

{
    ModuleContext module_ctx;
    module_ctx.m_stack_depth = context->m_stack_depth + 1;
std::string* module_content = Modules::PushPointerThroughStruct(node, &module_ctx);
    source->append(*module_content);
    delete module_content;
}
source->append(R"::(
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != ()::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor a, )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(_Accessor b)
        {
            return !(a == b);
        }
        )::");

                return source;
            }
        }
    }
}
