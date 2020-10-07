using System;
using System.Windows;
using RooStatsSim.Extension;
using System.Text.Json;

namespace RooStatsSim.UI.ACK
{
    /// <summary>
    /// Thanks.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProgramInfo : Window
    {
        // 프로그램 저작권 MIT 라이센스 공유
        const string _LICENSE = "Copyright (c) <2020> <Jooss287>\n" +
                                "이 프로그램은 오픈소스정신 하 MIT 라이센스를 가지며 사용자는 무상으로 취급해도 좋습니다." + 
                                "단, 수정&배포 시 저작권 표시 및 허가 표시를 바랍니다.\n" +
                                "저자 또는 저작권자는 소프트웨어에 관해 아무런 책임을 지지 않습니다.";
        // 원작 라그나로크 오리진 안내
        const string _ROO_URL = "https://community.gnjoy.com/RAGNAROKORIGIN";
        // 프로그램 버전
        const string _PROGRAM_VER = "v0.0";
        const string _LATEST_VER_API_URL = "https://api.github.com/repos/Jooss287/RooSim/releases/latest";
        // Github 주소
        const string _CONTACT_URL = "https://api.github.com/repos/Jooss287/RooSim/Issue \n" + 
                                    _EMAIL;
        const string _EMAIL = "Jooss287@gmail.com";
        // Library사용목록
        // 도와주신 분들
        const string _THANKS= "[프론]백은하, [프론]써노, [프론]코로나바이러스, [프론]달토끼, [프론]렌탈히어로MK3, [프론]영혼의트롤링";

        

        public ProgramInfo()
        {
            InitializeComponent();

            txt_license.Text = _LICENSE;
            txt_game_url.Text = _ROO_URL;
            txt_version.Text = _PROGRAM_VER;
            txt_contact.Text = _CONTACT_URL;
            txt_helpers.Text = _THANKS;
        }


        #region Version
        public static string Ver
        {
            get { return _PROGRAM_VER; }
        }
        public static string GetLeastVersion()
        {
            string api_response = APIExtension.callWebClient(_LATEST_VER_API_URL);
            var r = JsonDocument.Parse(api_response);
            //return Convert.ToString(r["tag_name"]);
            return "";
        }
        public static string GetLeastURL()
        {
            string api_response = APIExtension.callWebClient(_LATEST_VER_API_URL);
            var r = JsonDocument.Parse(api_response);
            //return Convert.ToString(r["html_url"]);
            return "";
        }

        public static bool IsLastestVer()
        {
            return string.Equals(GetLeastVersion(), _PROGRAM_VER);
        }
        #endregion
    }
}
