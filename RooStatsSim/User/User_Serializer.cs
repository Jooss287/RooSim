using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RooStatsSim.Extension;

namespace RooStatsSim.User
{
    class User_Serializer
    {
        const string file_name = "User.roo";
        public static void SaveDataBase(ref UserData User)
        {
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            serializeOptions.WriteIndented = true;

            string jsonString;
            jsonString = JsonSerializer.Serialize(User, serializeOptions);
            File.WriteAllText(file_name, jsonString);
        }

        public static void ReadDB(ref UserData DB)
        {
            if (!IsFileAvailable())
                return;

            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            serializeOptions.WriteIndented = true;

            string jsonString = File.ReadAllText(file_name);
            DB = JsonSerializer.Deserialize<UserData>(jsonString, serializeOptions);
        }

        public static bool IsFileAvailable()
        {
            FileInfo fi = new FileInfo(file_name);
            if (fi.Exists)
                return true;
            else
                return false;
        }
    }
}
