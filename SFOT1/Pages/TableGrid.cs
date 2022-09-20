using System.Data;
using Microsoft.AspNetCore.Components;
//using Microsoft.Data.SqlClient;
//using SFOT1.API;
//using SFOT1.API.Models.DB.Pro;
//using SFOT1.API.Models;
using SFOT1.Data;
using Newtonsoft.Json;

namespace SFOT1.Pages
{
    public partial class TableGrid
    {
//testtest
        public List<PlayerProp> PlayerInfo = new List<PlayerProp>();

        bool _isAsc;
        public string ImageSortFirst = "/Images/BlueUpArrow.png";
        public string ImageSortLast = "/Images/BlueUpArrow.png";
        public string ImageSortPos = "/Images/BlueUpArrow.png";
        public string ImageSortClub = "/Images/BlueUpArrow.png";
        public string ImageSortSchool = "/Images/BlueUpArrow.png";

        protected override void OnInitialized()
        {

            PlayerInfo = GetPlayerData(1157);

        }

        public static List<PlayerProp> GetPlayerData(int clubId)
        {
            List<PlayerProp> retVal = new List<PlayerProp>();

            using DataTable dt = PlayerData.GetPlayer(clubId);

            foreach (DataRow dr in dt.Rows)
            {
                PlayerProp pp = new PlayerProp();
                pp.LastName = dr["LastName"].ToString();
                pp.FirstName = dr["FirstName"].ToString();
                pp.Position = dr["Position"].ToString();
                pp.Club = dr["Club"].ToString();
                pp.School = dr["School"].ToString();

                retVal.Add(pp);
            }


            return retVal;
        }


        protected async Task PlayerSorting(string sortColumn)
        {

                _isAsc = !_isAsc;
                string sortImg = _isAsc ? "/Images/BlueUpArrow.png" : "/Images/BlueDownArrow.png";


                switch (sortColumn)
                {
                    case "LastName":
                        ImageSortLast = sortImg;

                        PlayerInfo = _isAsc
                            ? PlayerInfo.OrderBy(o => o.LastName).ToList()
                            : PlayerInfo.OrderByDescending(o => o.LastName).ToList();

                        break;
                    case "FirstName":
                        ImageSortFirst = sortImg;

                        PlayerInfo = _isAsc
                            ? PlayerInfo.OrderBy(o => o.FirstName).ToList()
                            : PlayerInfo.OrderByDescending(o => o.FirstName).ToList();

                        break;
                    case "Position":
                        ImageSortPos = sortImg;

                        PlayerInfo = _isAsc
                            ? PlayerInfo.OrderBy(o => o.Position).ToList()
                            : PlayerInfo.OrderByDescending(o => o.Position).ToList(); break;

                        break;
                    case "Club":
                        ImageSortClub = sortImg;

                        PlayerInfo = _isAsc
                            ? PlayerInfo.OrderBy(o => o.Club).ToList()
                            : PlayerInfo.OrderByDescending(o => o.Club).ToList();

                        break;
                    case "School":
                        ImageSortSchool = sortImg;

                        PlayerInfo = _isAsc
                            ? PlayerInfo.OrderBy(o => o.School).ToList()
                            : PlayerInfo.OrderByDescending(o => o.School).ToList();

                        break;
                }


        }


    }
}
