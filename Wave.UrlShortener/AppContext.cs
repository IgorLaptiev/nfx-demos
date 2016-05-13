using System;
using NFX;
using NFX.DataAccess.CRUD;
using NFX.DataAccess.MySQL;
using NFX.Serialization.JSON;
using NFX.Wave.Client;

namespace Wave.UrlShortener
{
    internal static class AppContext
    {
        public static ICRUDOperations DataStore
        {
            get { return App.DataStore as ICRUDOperations; }
        }

      /*  public static string FormJSON(Person person, Exception validationError = null)
        {
            return RecordModelGenerator.RowToRecordInitJSON(person, validationError).ToJSON();
        }*/
    }
}
