/* Empiria DevOps ********************************************************************************************
*                                                                                                            *
*  Solution : Empiria DevOps                                   System  : DevOps Web API                      *
*  Assembly : Empiria.DevOps.WebApi.dll                        Pattern : Information holder                  *
*  Type     : Application                                      License : Please read LICENSE.txt file        *
*                                                                                                            *
*  Summary  : Represents an executable client or server software application.                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Data;

namespace Empiria.DevOps {

  /// <summary>Represents an executable client or server software application.</summary>
  [DataModel("ECMApplications", "ApplicationId")]
  internal class Application : BaseObjectLite {

    #region Constructors and parsers

    private Application() {

    }


    static internal Application Parse(int id) {
      return BaseObjectFactory.Parse<Application>(id);
    }


    static internal Application Parse(string applicationKey) {
      Assertion.AssertObject(applicationKey, "applicationKey");

      return BaseObjectFactory.ParseWithFilter<Application>($"ApplicationKey = '{applicationKey}'");
    }


    protected override void OnLoadObjectData(DataRow row) {
      this.AppKey = (string) row["ApplicationKey"];
      this.Name = (string) row["ApplicationName"];
      this.Solution = (string) row["Solution"];
      this.Description = (string) row["Description"];
    }

    #endregion Constructors and parsers

    #region Properties

    [DataField("ApplicationKey")]
    public string AppKey {
      get;
      private set;
    }


    [DataField("ApplicationName")]
    public string Name {
      get;
      private set;
    }

    [DataField("Solution")]
    public string Solution {
      get;
      private set;
    }


    [DataField("Description")]
    public string Description {
      get;
      private set;
    }


    #endregion Properties

    #region Methods

    #endregion Methods

  }  // class Application

} // namespace Empiria.DevOps
