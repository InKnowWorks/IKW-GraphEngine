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
MessagePassingMethods(
NProtocolGroup* node, ModuleContext* context)
            {
                string* source = new string();
                
std::string method_name_1;
std::string send_message_method_1;
for (size_t iterator_1 = 0; iterator_1 < (node->protocolList)->size();++iterator_1)
{
if (!(*(node->protocolList))[iterator_1]->referencedNProtocol->is_http_protocol())
{
source->append(R"::(
        #region prototype definition template variables
        )::");
method_name_1 = *(*(node->protocolList))[iterator_1]->name;
if (node->type() == PGT_SERVER || node->type() == PGT_PROXY)
{
send_message_method_1 = "storage.SendMessage";
}
else
{
send_message_method_1 = "storage.SendMessage<" + *node->name + "Base>";
}
source->append(R"::(
        #endregion
        )::");
if (!(*(node->protocolList))[iterator_1]->referencedNProtocol->has_request() && !(*(node->protocolList))[iterator_1]->referencedNProtocol->has_response())
{
source->append(R"::(
        public unsafe static void )::");
source->append(Codegen::GetString(method_name_1));
source->append(R"::((this Trinity.Storage.IMessagePassingEndpoint storage)
        {
            byte* bufferPtr = stackalloc byte[TrinityProtocol.MsgHeader];
            *(int*)(bufferPtr) = TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = )::");
source->append(Codegen::GetString(get_comm_protocol_trinitymessagetype((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::( ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::)::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.TSL.)::");
source->append(Codegen::GetString(get_comm_class_basename(node)));
source->append(R"::(.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.)::");
source->append(Codegen::GetString(get_comm_protocol_type_string((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::(MessageType.)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(;
            )::");
source->append(Codegen::GetString(send_message_method_1));
source->append(R"::((bufferPtr, TrinityProtocol.MsgHeader);
        }
        )::");
}
else if ((*(node->protocolList))[iterator_1]->referencedNProtocol->has_request() && !(*(node->protocolList))[iterator_1]->referencedNProtocol->has_response())
{
source->append(R"::(
        public unsafe static void )::");
source->append(Codegen::GetString(method_name_1));
source->append(R"::((this Trinity.Storage.IMessagePassingEndpoint storage, )::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->request_message_struct));
source->append(R"::(Writer msg)
        {
            byte* bufferPtr = msg.buffer;
            *(int*)(bufferPtr) = msg.Length + TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = )::");
source->append(Codegen::GetString(get_comm_protocol_trinitymessagetype((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::( ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::)::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.TSL.)::");
source->append(Codegen::GetString(get_comm_class_basename(node)));
source->append(R"::(.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.)::");
source->append(Codegen::GetString(get_comm_protocol_type_string((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::(MessageType.)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(;
            )::");
source->append(Codegen::GetString(send_message_method_1));
source->append(R"::((bufferPtr, msg.Length + TrinityProtocol.MsgHeader);
        }
        )::");
}
else if (!(*(node->protocolList))[iterator_1]->referencedNProtocol->has_request() && (*(node->protocolList))[iterator_1]->referencedNProtocol->is_syn_req_rsp_protocol())
{
source->append(R"::(
        public unsafe static )::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->response_message_struct));
source->append(R"::(Reader )::");
source->append(Codegen::GetString(method_name_1));
source->append(R"::((this Trinity.Storage.IMessagePassingEndpoint storage)
        {
            byte* bufferPtr = stackalloc byte[TrinityProtocol.MsgHeader];
            *(int*)(bufferPtr) = TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = )::");
source->append(Codegen::GetString(get_comm_protocol_trinitymessagetype((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::( ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::)::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.TSL.)::");
source->append(Codegen::GetString(get_comm_class_basename(node)));
source->append(R"::(.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.)::");
source->append(Codegen::GetString(get_comm_protocol_type_string((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::(MessageType.)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(;
            TrinityResponse response;
            )::");
source->append(Codegen::GetString(send_message_method_1));
source->append(R"::((bufferPtr, TrinityProtocol.MsgHeader, out response);
            return new )::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->response_message_struct));
source->append(R"::(Reader(response.Buffer, response.Offset);
        }
        )::");
}
else if ((*(node->protocolList))[iterator_1]->referencedNProtocol->has_request() && (*(node->protocolList))[iterator_1]->referencedNProtocol->is_syn_req_rsp_protocol())
{
source->append(R"::(
        public unsafe static )::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->response_message_struct));
source->append(R"::(Reader )::");
source->append(Codegen::GetString(method_name_1));
source->append(R"::((this Trinity.Storage.IMessagePassingEndpoint storage, )::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->request_message_struct));
source->append(R"::(Writer msg)
        {
            byte* bufferPtr = msg.buffer;
            *(int*)(bufferPtr) = msg.Length + TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = )::");
source->append(Codegen::GetString(get_comm_protocol_trinitymessagetype((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::( ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::)::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.TSL.)::");
source->append(Codegen::GetString(get_comm_class_basename(node)));
source->append(R"::(.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.)::");
source->append(Codegen::GetString(get_comm_protocol_type_string((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::(MessageType.)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(;
            TrinityResponse response;
            )::");
source->append(Codegen::GetString(send_message_method_1));
source->append(R"::((bufferPtr, msg.Length + TrinityProtocol.MsgHeader, out response);
            return new )::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->response_message_struct));
source->append(R"::(Reader(response.Buffer, response.Offset);
        }
        )::");
}
else if (!(*(node->protocolList))[iterator_1]->referencedNProtocol->has_request() && (*(node->protocolList))[iterator_1]->referencedNProtocol->is_asyn_req_rsp_protocol())
{
source->append(R"::(
        public unsafe static Task<)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->response_message_struct));
source->append(R"::(Reader> )::");
source->append(Codegen::GetString(method_name_1));
source->append(R"::((this Trinity.Storage.IMessagePassingEndpoint storage)
        {
            byte* bufferPtr = stackalloc byte[TrinityProtocol.MsgHeader + TrinityProtocol.AsyncWithRspAdditionalHeaderLength];
            int token = Interlocked.Increment(ref )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(Base.s_)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(_token_counter);
            var task_source = new TaskCompletionSource<)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->response_message_struct));
source->append(R"::(Reader>();
            )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(Base.s_)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(_token_sources[token] = task_source;
            *(int*)(bufferPtr + TrinityProtocol.MsgHeader) = token;
            *(int*)(bufferPtr + TrinityProtocol.MsgHeader + sizeof(int)) = Global.CloudStorage.MyInstanceId;
            *(int*)(bufferPtr) = TrinityProtocol.TrinityMsgHeader + TrinityProtocol.AsyncWithRspAdditionalHeaderLength;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = )::");
source->append(Codegen::GetString(get_comm_protocol_trinitymessagetype((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::( ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::)::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.TSL.)::");
source->append(Codegen::GetString(get_comm_class_basename(node)));
source->append(R"::(.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.)::");
source->append(Codegen::GetString(get_comm_protocol_type_string((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::(MessageType.)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(;
            )::");
source->append(Codegen::GetString(send_message_method_1));
source->append(R"::((bufferPtr, TrinityProtocol.MsgHeader + TrinityProtocol.AsyncWithRspAdditionalHeaderLength);
            return task_source.Task;
        }
        )::");
}
else
{
source->append(R"::(
        public unsafe static Task<)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->response_message_struct));
source->append(R"::(Reader> )::");
source->append(Codegen::GetString(method_name_1));
source->append(R"::((this Trinity.Storage.IMessagePassingEndpoint storage, )::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->request_message_struct));
source->append(R"::(Writer msg)
        {
            byte** bufferPtrs = stackalloc byte*[2];
            int*   size       = stackalloc int[2];
            byte*  bufferPtr  = stackalloc byte[TrinityProtocol.MsgHeader + TrinityProtocol.AsyncWithRspAdditionalHeaderLength];
            bufferPtrs[0]     = bufferPtr;
            bufferPtrs[1]     = msg.buffer + TrinityProtocol.MsgHeader;
            size[0]           = TrinityProtocol.MsgHeader + TrinityProtocol.AsyncWithRspAdditionalHeaderLength;
            size[1]           = msg.Length;
            int token = Interlocked.Increment(ref )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(Base.s_)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(_token_counter);
            var task_source = new TaskCompletionSource<)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->referencedNProtocol->response_message_struct));
source->append(R"::(Reader>();
            )::");
source->append(Codegen::GetString(node->name));
source->append(R"::(Base.s_)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(_token_sources[token] = task_source;
            *(int*)(bufferPtr) = TrinityProtocol.TrinityMsgHeader + msg.Length + TrinityProtocol.AsyncWithRspAdditionalHeaderLength;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = )::");
source->append(Codegen::GetString(get_comm_protocol_trinitymessagetype((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::( ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::)::");
source->append(Codegen::GetString(Trinity::Codegen::GetNamespace()));
source->append(R"::(.TSL.)::");
source->append(Codegen::GetString(get_comm_class_basename(node)));
source->append(R"::(.)::");
source->append(Codegen::GetString(node->name));
source->append(R"::(.)::");
source->append(Codegen::GetString(get_comm_protocol_type_string((*(node->protocolList))[iterator_1]->referencedNProtocol)));
source->append(R"::(MessageType.)::");
source->append(Codegen::GetString((*(node->protocolList))[iterator_1]->name));
source->append(R"::(;
            *(int*)(bufferPtr + TrinityProtocol.MsgHeader) = token;
            *(int*)(bufferPtr + TrinityProtocol.MsgHeader + sizeof(int)) = Global.CloudStorage.MyInstanceId;
            )::");
source->append(Codegen::GetString(send_message_method_1));
source->append(R"::((bufferPtrs, size, 2);
            return task_source.Task;
        }
        )::");
}
}
}

                return source;
            }
        }
    }
}
