/* Empiria DevOps ********************************************************************************************
*                                                                                                            *
*  Solution : Empiria DevOps                                   System  : DevOps Web API                      *
*  Assembly : Empiria.DevOps.WebApi.dll                        Pattern : Web Api Controller                  *
*  Type     : GeneralMethodsController                         License : Please read LICENSE.txt file        *
*                                                                                                            *
*  Summary  : General purpose web methods for the DevOps Web Api.                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Net.Http;
using System.Web.Http;

using Empiria.WebApi;
using Empiria.WebApi.Models;

namespace Empiria.DevOps.WebApi {

  /// <summary>General purpose web methods for the DevOps Web Api.</summary>
  public class GeneralMethodsController : WebApiController {

    #region Public APIs

    /// <summary>Creates a serial number for a specific physical server.</summary>
    /// <param name="hardwareCode">The code assigned to the physical hardware.</param>
    /// <remarks>An Empiria-DevOps-DeploymentID request header must be supplied.</remarks>
    [HttpPost, AllowAnonymous]
    [Route("v1/general/serial-number")]
    public SingleObjectModel CreateSerialNumber([FromBody] string hardwareCode) {
      try {
        base.RequireBody(hardwareCode);

        Deployment deployment = GetDeployment(this.Request);

        var cryptographer = new DevOpsCryptographer(deployment);

        string serialNumber = cryptographer.CreateSerialNumber(hardwareCode);

        return new SingleObjectModel(this.Request, serialNumber);

      } catch (Exception e) {
        throw base.CreateHttpException(e);
      }
    }


    /// <summary>Gets a protected string encrypted according to the caller rules.</summary>
    /// <param name="plainText">The string to be encrypted.</param>
    /// <remarks>An Empiria-DevOps-DeploymentID request header must be supplied.</remarks>
    [HttpPost, AllowAnonymous]
    [Route("v1/general/protect-string")]
    public SingleObjectModel ProtectString([FromBody] string plainText) {
      try {
        base.RequireBody(plainText);

        Deployment deployment = GetDeployment(this.Request);

        var cryptographer = new DevOpsCryptographer(deployment);

        string encryptedValue = cryptographer.Encrypt(plainText);

        return new SingleObjectModel(this.Request, encryptedValue);

      } catch (Exception e) {
        throw base.CreateHttpException(e);
      }
    }

    #endregion Public APIs

    #region Private methods

    private Deployment GetDeployment(HttpRequestMessage request) {
      DeploymentID deploymentID = base.GetRequestHeader<DeploymentID>(DeploymentID.RequestHeaderName);

      return Deployment.Parse(deploymentID);
    }

    #endregion Private methods

  }  // class GeneralMethodsController

}  // namespace Empiria.DevOps.WebApi
