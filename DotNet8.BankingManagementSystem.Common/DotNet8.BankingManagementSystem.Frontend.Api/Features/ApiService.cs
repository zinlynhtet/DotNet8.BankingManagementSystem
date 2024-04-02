﻿using Azure;
using DotNet8.BankingManagementSystem.Frontend.Api.Features.Account;
using DotNet8.BankingManagementSystem.Frontend.Api.Features.State;
using DotNet8.BankingManagementSystem.Frontend.Api.Features.Township;
using DotNet8.BankingManagementSystem.Frontend.Api.Services;
using DotNet8.BankingManagementSystem.Models.State;
using DotNet8.BankingManagementSystem.Models.TownShip;
using Microsoft.Identity.Client;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.BankingManagementSystem.Frontend.Api.Features
{
    public class ApiService
    {
        private readonly EnumApiType _enumApiType;
        private readonly IAccountApi _accountApi;
        private readonly AccountService _accountService;
        private readonly IStateApi _stateApi;
        private readonly StateService _stateService;
        private readonly ITownshipApi _townshipApi;
        private readonly TownshipService _townshipService;

        public ApiService(Config config, AccountService accountService, IAccountApi accountApi, IStateApi stateApi, StateService stateService, ITownshipApi townshipApi, TownshipService townshipService)
        {
            _accountService = accountService;
            _accountApi = accountApi;
            _enumApiType = config.EnumApiType;
            _stateApi = stateApi;
            _stateService = stateService;
            _townshipApi = townshipApi;
            _townshipService = townshipService;
        }

        public async Task<AccountListResponseModel> GetAccounts()
        {
            return _enumApiType == EnumApiType.LocalStorage
                ? await _accountService.GetAccounts()
                : await _accountApi.GetAccounts();
        }

        //Task<AccountListResponseModel> GetAccountList(int pageNo, int pageSize);

        public async Task<AccountResponseModel> GetAccount(string accountNo)
        {
            return _enumApiType == EnumApiType.LocalStorage
                ? await _accountService.GetAccount(accountNo)
                : await _accountApi.GetAccount(accountNo);
        }

        public async Task<AccountResponseModel> CreateAccount(AccountRequestModel requestModel)
        {
            return _enumApiType == EnumApiType.LocalStorage
                ? await _accountService.CreateAccount(requestModel)
                : await _accountApi.CreateAccount(requestModel);
        }

        public async Task<AccountResponseModel> UpdateAccount(string accountNo, AccountRequestModel requestModel)
        {
            return _enumApiType == EnumApiType.LocalStorage
                ? await _accountService.UpdateAccount(accountNo, requestModel)
                : await _accountApi.UpdateAccount(accountNo, requestModel);
        }

        public async Task<AccountResponseModel> DeleteAccount(string accountNo)
        {
            return _enumApiType == EnumApiType.LocalStorage
                ? await _accountService.DeleteAccount(accountNo)
                : await _accountApi.DeleteAccount(accountNo);
        }

        #region State
        public async Task<StateListResponseModel> GetStates()
        {
            return _enumApiType == EnumApiType.LocalStorage
                ? await _stateApi.GetStates()
                : await _stateService.GetStates();
        }

        public async Task<StateListResponseModel> GetStates(int pageNo, int pageSize)
        {
            return _enumApiType == EnumApiType.LocalStorage
                ? await _stateApi.GetStateList(pageNo, pageSize)
                : await _stateService.GetStateList(pageNo, pageSize);
        }

        public async Task<StateResponseModel> GetStateByCode(string stateCode)
        {
            return _enumApiType == EnumApiType.LocalStorage
               ? await _stateApi.GetStateByCode(stateCode)
               : await _stateService.GetStateByCode(stateCode);
        }

        public async Task<StateResponseModel> CreateState(StateRequestModel requestModel)
        {
            return _enumApiType == EnumApiType.LocalStorage
              ? await _stateApi.CreateState(requestModel)
              : await _stateService.CreateState(requestModel);
        }

        public async Task<StateResponseModel> UpdateState(string stateCode, StateRequestModel requestModel)
        {
            return _enumApiType == EnumApiType.LocalStorage
              ? await _stateApi.UpdateState(stateCode, requestModel)
              : await _stateService.UpdateState(stateCode, requestModel);
        }

        public async Task<StateResponseModel> DeleteState(string stateCode)
        {
            return _enumApiType == EnumApiType.LocalStorage
              ? await _stateApi.DeleteState(stateCode)
              : await _stateService.DeleteState(stateCode);
        }
        #endregion

        #region TownShip
        public async Task<TownshipListResponceModel> GetTownships(int pageNo, int pageSize)
        {
            return _enumApiType == EnumApiType.LocalStorage
              ? await _townshipApi.GetTownShipList(pageNo, pageSize)
              : await _townshipService.GetTownShipList(pageNo, pageSize);
        }

        public async Task<TownshipResponseModel> GetTownShipByCode(string townshipCode)
        {
            return _enumApiType == EnumApiType.LocalStorage
             ? await _townshipApi.GetTownShipByCode(townshipCode)
             : await _townshipService.GetTownShipByCode(townshipCode);
        }

        public async Task<TownshipResponseModel> CreateTownship(TownshipRequestModel requestModel)
        {
            return _enumApiType == EnumApiType.LocalStorage
           ? await _townshipApi.CreateTownship(requestModel)
           : await _townshipService.CreateTownship(requestModel);
        }

        public async Task<TownshipResponseModel> UpdateTownship(string townshipCode, 
            TownshipRequestModel requestModel)
        {
            return _enumApiType == EnumApiType.LocalStorage
          ? await _townshipApi.UpdateTownship(townshipCode,requestModel)
          : await _townshipService.UpdateTownship(townshipCode,requestModel);
        }

        public async Task<TownshipResponseModel> DeleteTownship(string townshipCode)
        {
            return _enumApiType == EnumApiType.LocalStorage
          ? await _townshipApi.DeleteTownship(townshipCode)
          : await _townshipService.DeleteTownship(townshipCode);
        }

        public async Task<TownshipListResponceModel> GetTownShipByStateCode(string stateCode)
        {
            return _enumApiType == EnumApiType.LocalStorage
        ? await _townshipApi.GetTownShipByStateCode(stateCode)
        : await _townshipService.GetTownShipByStateCode(stateCode);
        }
        #endregion
    }
}