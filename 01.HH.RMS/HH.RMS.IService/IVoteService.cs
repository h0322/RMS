using HH.RMS.Common.Constant;
using HH.RMS.IService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.IService
{
    public interface IVoteService
    {
        List<VoteModel> QueryVote();
        ResultType InsertVote(VoteModel model);
        List<VoteBoxModel> QueryVoteBoxByVoteId(long voteId);
        ResultType InsertVoteBox(VoteBoxModel model);
        List<VoteLogModel> QueryVoteLog();
        ResultType InsertVoteLog(VoteLogModel model);
    }
}
