/* Empiria DevOps ********************************************************************************************
*                                                                                                            *
*  Solution : Empiria DevOps                                   System  : DevOps Web API                      *
*  Assembly : Empiria.DevOps.WebApi.dll                        Pattern : Information holder                  *
*  Type     : Environment                                      License : Please read LICENSE.txt file        *
*                                                                                                            *
*  Summary  : Represents a physical executable context or environment where software solutions runs.         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Data;

namespace Empiria.DevOps {

  /// <summary>Represents a physical executable context or environment where
  /// software solutions runs.</summary>
  [DataModel("ECMEnvironments", "EnvironmentId")]
  internal class Environment : BaseObjectLite {

    #region Constructors and parsers

    private Environment() {

    }


    static internal Environment Parse(int id) {
      return BaseObjectFactory.Parse<Environment>(id);
    }


    static internal Environment Parse(string serialNumber) {
      Assertion.AssertObject(serialNumber, "serialNumber");

      return BaseObjectFactory.ParseWithFilter<Environment>($"SerialNumber = '{serialNumber}'");
    }


    protected override void OnLoadObjectData(DataRow row) {
      this.SerialNumber = (string) row["SerialNumber"];
      this.Name = (string) row["EnvironmentName"];
      this.Description = (string) row["Description"];
      this.Owner = (string) row["Owner"];
    }

    #endregion Constructors and parsers

    #region Properties

    [DataField("SerialNumber")]
    public string SerialNumber {
      get;
      private set;
    }


    [DataField("Name")]
    public string Name {
      get;
      private set;
    }


    [DataField("Description")]
    public string Description {
      get;
      private set;
    }


    [DataField("Owner")]
    public string Owner {
      get;
      private set;
    }

    #endregion Properties

    #region Methods

    #endregion Methods

  }  // class Environment

} // namespace Empiria.DevOps
