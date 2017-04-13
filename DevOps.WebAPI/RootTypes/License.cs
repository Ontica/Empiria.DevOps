﻿/* Empiria DevOps ********************************************************************************************
*                                                                                                            *
*  Solution : Empiria DevOps                                   System  : DevOps Web API                      *
*  Assembly : Empiria.DevOps.WebApi.dll                        Pattern : Information holder                  *
*  Type     : License                                          License : Please read LICENSE.txt file        *
*                                                                                                            *
*  Summary  : Contains information about a customer's Empiria solution license.                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Data;

using Empiria.Json;

namespace Empiria.DevOps {

  /// <summary>Contains information about a customer's Empiria solution license.</summary>
  [DataModel("ECMLicenses", "LicenseId")]
  internal class License : BaseObjectLite {

    #region Constructors and parsers

    private License() {

    }


    static internal License Parse(int id) {
      return BaseObjectFactory.Parse<License>(id);
    }


    static internal License Parse(string licenseNumber) {
      Assertion.AssertObject(licenseNumber, "licenseNumber");

      return BaseObjectFactory.ParseWithFilter<License>($"LicenseNumber = '{licenseNumber}'");
    }


    protected override void OnLoadObjectData(DataRow row) {
      this.LicenseName = (string) row["LicenseName"];
      this.LicenseNumber = (string) row["LicenseNumber"];
      this.Customer = (string) row["Customer"];
      this.LoadSecurityValues((string) row["SecurityValues"]);
    }

    #endregion Constructors and parsers

    #region Properties

    public string Customer {
      get;
      private set;
    }


    public string LicenseName {
      get;
      private set;
    }


    public string LicenseNumber {
      get;
      private set;
    }


    public byte[] Key {
      get;
      private set;
    }


    public byte[] IV {
      get;
      private set;
    }


    public byte[] LKey {
      get;
      private set;
    }

    #endregion Properties

    #region Methods

    private void LoadSecurityValues(string jsonString) {
      var json = JsonObject.Parse(jsonString);

      this.IV = json.GetList<byte>("IV").ToArray();
      this.Key = json.GetList<byte>("Key").ToArray();
      this.LKey = json.GetList<byte>("LKey").ToArray();
    }

    #endregion Methods

  }  // class License

} // namespace Empiria.DevOps
