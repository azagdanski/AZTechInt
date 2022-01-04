using AZTechInt.Modele;
using AZTechInt.Serwisy;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZTechInt.SerwisyBazy
{
    public class BazaSQL : Serwis
    {
        private readonly IDbConnection _con;
        public BazaSQL(IDbConnection c) { _con = c; }
        public LodzModel PobierzJednaLodz(string LodzId)
        {

            LodzModel l = new LodzModel();
            string sql = @"SELECT LodzId, Nazwa, Koszt, Rodzaj, Dlugosc, Wysokosc, LiczbaMiejsc, Zdjecie FROM Lodz WHERE LodzId=@LodzId";
            l = _con.Query<LodzModel>(sql, new
            {
                @LodzId = LodzId
            }).FirstOrDefault();
            return l;
        }


        public IEnumerable<LodzModel> PobierzWszystkieLodki()
        {
            List<LodzModel> lodzlist = new List<LodzModel>();
            string sqlquery = @" SELECT LodzId, Nazwa, Koszt, Rodzaj, Dlugosc, Wysokosc, LiczbaMiejsc, Zdjecie FROM Lodz";
            lodzlist = _con.Query<LodzModel>(sqlquery).ToList();
            return lodzlist;
        }

        public Zamowienie ZapiszZam(Zamowienie z)
        {
            string sql = "[dbo].[UtworzZamowienie]";
            var param = new DynamicParameters();
            param.Add("@LodzId", z.LodzId);
            param.Add("@RezerwacjaOd", z.RezerwacjaOd);
            param.Add("@RezerwacjaDo", z.RezerwacjaDo);
            param.Add("@ImieNazwisko", z.ImieNazwisko);
            param.Add("@AdresEmail", z.AdresEmail);
            param.Add("@Telefon", z.Telefon);
            param.Add("@DodatkoweProsby", z.DodatkoweProsby);
            param.Add("@ZamowienieId", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            param.Add("@NadanyNumer", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            param.Add("@Suma", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            _con.Execute(sql, param, commandType: CommandType.StoredProcedure);
            z.NadanyNumer = param.Get<string>("@NadanyNumer");
            z.Suma = param.Get<string>("@Suma");
            z.ZamowienieId = param.Get<string>("@ZamowienieId");
            return z;
        }
    }
}
