﻿namespace DotNet8.BankingManagementSystem.Backend.Features.State;

[ApiController]
[Route("api/[controller]")]
public class StateController : BaseController
{
    private readonly StateService _stateService;

    public StateController(StateService stateService)
    {
        _stateService = stateService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStates()
    {
        try
        {
            var model = await _stateService.GetStates();
            return Ok(model);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    #region Get States

    [HttpGet("{pageNo}/{pageSize}")]
    public async Task<IActionResult> GetStateList(int pageNo, int pageSize)
    {
        try
        {
            var model = await _stateService.GetStateList(pageNo, pageSize);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    #endregion

    #region Get State

    [HttpGet("{stateCode}")]
    public async Task<IActionResult> GetStateByCode(string stateCode)
    {
        try
        {
            var model = await _stateService.GetStateByCode(stateCode);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    #endregion

    #region Create State

    [HttpPost]
    public async Task<IActionResult> CreateState(StateRequestModel requestModel)
    {
        try
        {
            var model = await _stateService.CreateState(requestModel);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    #endregion

    #region UpdateState

    [HttpPut("{stateCode}")]
    public async Task<IActionResult> UpdateState(string stateCode, StateRequestModel requestModel)
    {
        try
        {
            var model = await _stateService.UpdateState(stateCode, requestModel);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    #endregion

    #region DeleteState

    [HttpDelete("{stateCode}")]
    public async Task<IActionResult> DeleteState(string stateCode)
    {
        try
        {
            var model = await _stateService.DeleteState(stateCode);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    #endregion
}