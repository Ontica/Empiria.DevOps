/* Empiria DevOps ********************************************************************************************
*                                                                                                            *
*  Solution : Empiria DevOps                                   System  : DevOps Web API                      *
*  Assembly : Empiria.DevOps.WebApi.dll                        Pattern : Web Api Controller                  *
*  Type     : GetArtifactsController                           License : Please read LICENSE.txt file        *
*                                                                                                            *
*  Summary  : Gets artifacts information.                                                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.DevOps.WebApi {

  /// <summary>Gets artifacts information.</summary>
  public class GetArtifactsController : WebApiController {

    #region Public APIs

    [HttpGet, AllowAnonymous]
    [Route("v1/tests/app/{applicationUID}")]
    public SingleObjectModel GetApplication([FromUri] string applicationUID) {
      try {
        var app = Application.Parse(applicationUID);

        return new SingleObjectModel(this.Request, app);

      } catch (Exception e) {
        throw base.CreateHttpException(e);

      }
    }


    [HttpGet, AllowAnonymous]
    [Route("v1/tests/environment/{environmentUID}")]
    public SingleObjectModel GetEnvironment([FromUri] string environmentUID) {
      try {
        var environment = Environment.Parse(environmentUID);

        return new SingleObjectModel(this.Request, environment);

      } catch (Exception e) {
        throw base.CreateHttpException(e);

      }
    }


    [HttpGet, AllowAnonymous]
    [Route("v1/tests/license/{licenseUID}")]
    public SingleObjectModel GetLicense([FromUri] string licenseUID) {
      try {
        var license = License.Parse(licenseUID);

        return new SingleObjectModel(this.Request, license);

      } catch (Exception e) {
        throw base.CreateHttpException(e);

      }
    }

    #endregion Public APIs

    #region Private methods

    #endregion Private methods

  }  // class GetArtifactsController

}  // namespace Empiria.DevOps.WebApi
