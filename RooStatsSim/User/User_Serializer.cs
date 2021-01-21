using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RooStatsSim.Extension;

namespace RooStatsSim.User
{
    class User_Serializer
    {
        const string default_path = "User\\";
        const string default_file_name = "User";
        const string default_file_extension = ".roo";
        public static void SaveDataBase(UserData User, int file_number = 1)
        {
            string file_name = string.Format("{0}{1}{2}{3}", default_path, default_file_name, file_number, default_file_extension);
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            //serializeOptions.Converters.Add(new JsonConvertExt_List_class_DB());
            serializeOptions.WriteIndented = true;

            string jsonString;
            jsonString = JsonSerializer.Serialize(User, serializeOptions);
            File.WriteAllText(file_name, jsonString);
        }

        public static void ReadDB(ref UserData User, int file_number = 1)
        {
            string file_name = string.Format("{0}{1}{2}{3}", default_path, default_file_name, file_number, default_file_extension);
            if (!ResourceExtension.IsFileExists(file_name))
            {
                User = new UserData();
                return;
            }

            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            serializeOptions.Converters.Add(new JsonConvertExt_List_class_DB());
            //serializeOptions.Converters.Add(new JsonConvertExt_ObserveList_class_DB());
            serializeOptions.WriteIndented = true;

            string jsonString = File.ReadAllText(file_name);
            User = JsonSerializer.Deserialize<UserData>(jsonString, serializeOptions);
        }
    }
}
