using AutoMapper;
using System.Collections.Generic;
using VideoRental.Common.BaseService;
using VideoRental.EntityModel.Entities;
using VideoRental.Repository.Interfaces;
using VideoRental.Service.Interfaces;
using VideoRental.ViewModel.Views;
using System;
using System.Transactions;
using System.Data.Entity.Core;

namespace VideoRental.Service.Implementations
{
    public class UserDetailService : BaseService<UserDetail>, IUserDetailService
    {
        private readonly IUserDetailRepository _userDetailRepository;

        public UserDetailService(IUserDetailRepository userDetailRepository)
            : base(userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }

        public List<UserDetailView> GetUserDetailViewList()
        {
            var list = new List<UserDetailView>();
            var request = _userDetailRepository.GetAll();
            foreach (var item in request)
            {
                var model = new UserDetailView();               
                Mapper.Map(item, model);
                list.Add(model);
            }

            return list;
        }

        public UserDetailView UpdateUserDetailView(UserDetailView newEntity)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    var oldEntity = _userDetailRepository.GetById(newEntity.Id);

                    Mapper.Map(newEntity, oldEntity);
                    var model = _userDetailRepository.Update(oldEntity);

                    ts.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw ex;
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }
            catch (UpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newEntity;
        }
    }
}
