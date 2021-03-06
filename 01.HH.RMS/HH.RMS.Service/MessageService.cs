﻿using HH.RMS.Common.Constant;
using HH.RMS.Entity;
using HH.RMS.Repository;
using HH.RMS.Repository.Interface;
using HH.RMS.IService;
using HH.RMS.IService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Service
{
    public class MessageService : IMessageService
    {
        private IRepository<MessageEntity> _messageRepository;
        public MessageService(IRepository<MessageEntity> messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public ResultType InsertMessage(MessageModel model)
        {
            try
            {
                var entity = MessageModel.EntityMapper<MessageEntity>(model);
                using (var db = new ApplicationDbContext())
                {
                    int result = _messageRepository.Insert(db, entity);
                    if (result > 0)
                    {
                        return ResultType.Success;
                    }
                    return ResultType.Fail;
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("MessageService.InsertMessage", ex);
                return ResultType.SystemError;
            }
        }
        public GridModel QueryMessageToGrid(PagerModel pager)
        {
            return null;
        }
        public MessageModel QueryMessageById(long id)
        {
            try
            {

                using (var db = new ApplicationDbContext())
                {
                    var entity = _messageRepository.Query(db).Where(m => m.id == id).FirstOrDefault();
                    if (entity == null)
                    {
                        return null;
                    }
                    return MessageModel.ModelMapper<MessageModel>(entity);
                }
            }
            catch (Exception ex)
            {
                Config.log.Error("MessageService.QueryMessageById", ex);
                return  null;
            }
        }
    }
}
