using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public partial class Administratie
    {
        private List<TableCell> tableCells;
        private TableCell[][] SporenArray;
        private int[][] Lijnen;

        // Vult de overzichtstabel
        public void OverzichtInit()
        {
            SporenArray = Sporenarray();
            Lijnen = Lijnenarray();
            VulSpoornummers();
            VulLijnnummers();
            VulSporen();
            VulTrams();
        }

        // Maakt een 19 bij 23 tabel aan waarbij alle
        // onnodige 'Cells' leeg worden gelaten
        public Table CreateTable(Table t)
        {
            t.Width = new Unit("100%");
            t.Height = new Unit("100%");
            int rowCount = 23;
            int colCount = 19;
            for (int row = 0; row < rowCount; row++)
            {
                TableRow r = new TableRow();
                for (int col = 0; col < colCount; col++)
                {
                    TableCell c = new TableCell();
                    //c.Text = col + ", " + row;
                    c.ID = "c" + col + "-" + row;
                    c.Width = new Unit(Convert.ToString(100 / rowCount) + "%");
                    c.Height = new Unit("35px");

                    // Sporen de spoorDefault CSS-klasse geven
                    if (col <= 8 && row == 0 ||
                        col >= 10 && col <= 14 && row == 0 ||
                        col == 16 && row == 0 ||
                        col == 18 && row == 0 ||
                        col <= 10 && row == 13 ||
                        col >= 12 && col <= 15 && row == 13 ||
                        col == 17 && row >= 13)
                    {
                        c.CssClass = "spoorDefault";
                    }

                    // Sectoren de sectorDefault CSS-klasse geven
                    if (col <= 8 && row == 1 ||
                        col >= 10 && col <= 14 && row == 1 ||
                        col == 16 && row == 1 ||
                        col == 18 && row == 1 ||
                        col <= 10 && row == 14 ||
                        col >= 12 && col <= 15 && row == 14)
                    {
                        c.CssClass = "sectorDefault";
                    }

                    //OLD
                    //if (col >= 3 && col <= 16 && row == 22 ||
                    //    col >= 6 && col <= 16 && row == 21 ||
                    //    col >= 7 && col <= 9 && row == 5 ||
                    //    col >= 7 && col <= 16 && row == 20 ||
                    //    col >= 8 && col <= 16 && row == 19 ||
                    //    col == 9 && row <= 5 ||
                    //    col <= 9 && row >= 6 && row <= 12 ||
                    //    col >= 9 && col <= 11 && row == 18 ||
                    //    col == 10 && row >= 9 && row <= 12 ||
                    //    col >= 11 && col <= 15 && row >= 6 && row <= 12 ||
                    //    col == 11 && row >= 13 && row <= 17 ||
                    //    col == 13 && row == 18 ||
                    //    col == 15 && row <= 5 ||
                    //    col == 16 && row >= 11 && row <= 18 ||
                    //    col == 17 && row <= 6 ||
                    //    col >= 17 && row >= 7 && row <= 12)
                    //{
                    //    // niks
                    //}
                    //else
                    //{
                    //    c.Text = c.ID;
                    //}

                    tableCells.Add(c);
                    r.Cells.Add(c);
                }
                t.Rows.Add(r);
            }
            return t;
        }

        // Verkort het zoeken naar de 'Cell' op de 'col', 'row' positie
        private TableCell GetCell(int col, int row)
        {
            string id = "c" + col + "-" + row;

            foreach (TableCell tc in tableCells)
            {
                if (tc.ID == id)
                {
                    return tc;
                }
            }
            return null;
        }

        // Koppelt elke sector van elk spoor aan 'Cells' van de tabel
        // namens een array. Met deze array is het dus mogelijk om 
        // met alleen het spoor en sectornummer de bijbehorende 'Cell'
        // te vinden. (bijv. SporenArray()[12][2] haalt de 'Cell' van de
        // tweede sector van het 12e spoor op)
        public TableCell[][] Sporenarray()
        {
            TableCell[][] sporenArray = new TableCell[78][];

            sporenArray[12] = new TableCell[2] { null, GetCell(18, 13) };
            sporenArray[13] = new TableCell[2] { null, GetCell(18, 14) };
            sporenArray[14] = new TableCell[2] { null, GetCell(18, 15) };
            sporenArray[15] = new TableCell[2] { null, GetCell(18, 16) };
            sporenArray[16] = new TableCell[2] { null, GetCell(18, 17) };
            sporenArray[17] = new TableCell[2] { null, GetCell(18, 18) };
            sporenArray[18] = new TableCell[2] { null, GetCell(18, 19) };
            sporenArray[19] = new TableCell[2] { null, GetCell(18, 20) };
            sporenArray[20] = new TableCell[2] { null, GetCell(18, 21) };
            sporenArray[21] = new TableCell[2] { null, GetCell(18, 22) };
            sporenArray[30] = new TableCell[4] { GetCell(8, 1), GetCell(8, 2), GetCell(8, 3), GetCell(8, 4) };
            sporenArray[31] = new TableCell[4] { GetCell(7, 1), GetCell(7, 2), GetCell(7, 3), GetCell(7, 4) };
            sporenArray[32] = new TableCell[5] { GetCell(6, 1), GetCell(6, 2), GetCell(6, 3), GetCell(6, 4), GetCell(6, 5) };
            sporenArray[33] = new TableCell[5] { GetCell(5, 1), GetCell(5, 2), GetCell(5, 3), GetCell(5, 4), GetCell(5, 5) };
            sporenArray[34] = new TableCell[5] { GetCell(4, 1), GetCell(4, 2), GetCell(4, 3), GetCell(4, 4), GetCell(4, 5) };
            sporenArray[35] = new TableCell[5] { GetCell(3, 1), GetCell(3, 2), GetCell(3, 3), GetCell(3, 4), GetCell(3, 5) };
            sporenArray[36] = new TableCell[5] { GetCell(2, 1), GetCell(2, 2), GetCell(2, 3), GetCell(2, 4), GetCell(2, 5) };
            sporenArray[37] = new TableCell[5] { GetCell(1, 1), GetCell(1, 2), GetCell(1, 3), GetCell(1, 4), GetCell(1, 5) };
            sporenArray[38] = new TableCell[5] { GetCell(0, 1), GetCell(0, 2), GetCell(0, 3), GetCell(0, 4), GetCell(0, 5) };
            sporenArray[40] = new TableCell[8] { GetCell(10, 1), GetCell(10, 2), GetCell(10, 3), GetCell(10, 4), GetCell(10, 5), GetCell(10, 6), GetCell(10, 7), GetCell(10, 8) };
            sporenArray[41] = new TableCell[5] { GetCell(11, 1), GetCell(11, 2), GetCell(11, 3), GetCell(11, 4), GetCell(11, 5) };
            sporenArray[42] = new TableCell[5] { GetCell(12, 1), GetCell(12, 2), GetCell(12, 3), GetCell(12, 4), GetCell(12, 5) };
            sporenArray[43] = new TableCell[5] { GetCell(13, 1), GetCell(13, 2), GetCell(13, 3), GetCell(13, 4), GetCell(13, 5) };
            sporenArray[44] = new TableCell[5] { GetCell(14, 1), GetCell(14, 2), GetCell(14, 3), GetCell(14, 4), GetCell(14, 5) };
            sporenArray[45] = new TableCell[10] { GetCell(16, 1), GetCell(16, 2), GetCell(16, 3), GetCell(16, 4), GetCell(16, 5), GetCell(16, 6), GetCell(16, 7), GetCell(16, 8), GetCell(16, 9), GetCell(16, 10) };
            sporenArray[51] = new TableCell[7] { GetCell(6, 14), GetCell(6, 15), GetCell(6, 16), GetCell(6, 17), GetCell(6, 18), GetCell(6, 19), GetCell(6, 20) };
            sporenArray[52] = new TableCell[8] { GetCell(5, 14), GetCell(5, 15), GetCell(5, 16), GetCell(5, 17), GetCell(5, 18), GetCell(5, 19), GetCell(5, 20), GetCell(5, 21) };
            sporenArray[53] = new TableCell[8] { GetCell(4, 14), GetCell(4, 15), GetCell(4, 16), GetCell(4, 17), GetCell(4, 18), GetCell(4, 19), GetCell(4, 20), GetCell(4, 21) };
            sporenArray[54] = new TableCell[8] { GetCell(3, 14), GetCell(3, 15), GetCell(3, 16), GetCell(3, 17), GetCell(3, 18), GetCell(3, 19), GetCell(3, 20), GetCell(3, 21) };
            sporenArray[55] = new TableCell[9] { GetCell(2, 14), GetCell(2, 15), GetCell(2, 16), GetCell(2, 17), GetCell(2, 18), GetCell(2, 19), GetCell(2, 20), GetCell(2, 21), GetCell(2, 22) };
            sporenArray[56] = new TableCell[9] { GetCell(1, 14), GetCell(1, 15), GetCell(1, 16), GetCell(1, 17), GetCell(1, 18), GetCell(1, 19), GetCell(1, 20), GetCell(1, 21), GetCell(1, 22) };
            sporenArray[57] = new TableCell[9] { GetCell(0, 14), GetCell(0, 15), GetCell(0, 16), GetCell(0, 17), GetCell(0, 18), GetCell(0, 19), GetCell(0, 20), GetCell(0, 21), GetCell(0, 22) };
            sporenArray[58] = new TableCell[6] { GetCell(18, 1), GetCell(18, 2), GetCell(18, 3), GetCell(18, 4), GetCell(18, 5), GetCell(18, 6) };
            sporenArray[61] = new TableCell[4] { GetCell(10, 14), GetCell(10, 15), GetCell(10, 16), GetCell(10, 17) };
            sporenArray[62] = new TableCell[4] { GetCell(9, 14), GetCell(9, 15), GetCell(9, 16), GetCell(9, 17) };
            sporenArray[63] = new TableCell[5] { GetCell(8, 14), GetCell(8, 15), GetCell(8, 16), GetCell(8, 17), GetCell(8, 18) };
            sporenArray[64] = new TableCell[6] { GetCell(7, 14), GetCell(7, 15), GetCell(7, 16), GetCell(7, 17), GetCell(7, 18), GetCell(7, 19) };
            sporenArray[74] = new TableCell[5] { GetCell(12, 14), GetCell(12, 15), GetCell(12, 16), GetCell(12, 17), GetCell(12, 18) };
            sporenArray[75] = new TableCell[4] { GetCell(13, 14), GetCell(13, 15), GetCell(13, 16), GetCell(13, 17) };
            sporenArray[76] = new TableCell[5] { GetCell(14, 14), GetCell(14, 15), GetCell(14, 16), GetCell(14, 17), GetCell(14, 18) };
            sporenArray[77] = new TableCell[5] { GetCell(15, 14), GetCell(15, 15), GetCell(15, 16), GetCell(15, 17), GetCell(15, 18) };

            return sporenArray;
        }

        // Een array om bij te houden welk spoor bij welke lijn hoort
        // om dit te gebruiken tijdens het sorteeralgoritme van de trams
        private int[][] Lijnenarray()
        {
            int[][] lijnenArray = new int[10][];

            lijnenArray[0] = new int[4] { 1, 36, 43, 51 };
            lijnenArray[1] = new int[5] { 2, 38, 34, 55, 63 };
            lijnenArray[2] = new int[2] { 5, 42 };
            lijnenArray[3] = new int[4] { 5, 37, 56, 54 };
            lijnenArray[4] = new int[4] { 10, 32, 41, 62 };
            lijnenArray[5] = new int[3] { 13, 44, 53 };
            lijnenArray[6] = new int[3] { 17, 52, 45 };
            lijnenArray[7] = new int[5] { 16, 30, 35, 33, 57 };
            lijnenArray[8] = new int[5] { 24, 30, 35, 33, 57 };
            lijnenArray[9] = new int[20] { 0, 31, 40, 58, 61, 64, 74, 75, 76, 77, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };

            return lijnenArray;
        }

        // Vult de 'Cells' in de tabel die de spoornummers bijhouden
        // met de bijbehorende spoornummers
        private void VulSpoornummers()
        {
            GetCell(0, 0).Text = "38";
            GetCell(1, 0).Text = "37";
            GetCell(2, 0).Text = "36";
            GetCell(3, 0).Text = "35";
            GetCell(4, 0).Text = "34";
            GetCell(5, 0).Text = "33";
            GetCell(6, 0).Text = "32";
            GetCell(7, 0).Text = "31";
            GetCell(8, 0).Text = "30";
            GetCell(10, 0).Text = "40";
            GetCell(11, 0).Text = "41";
            GetCell(12, 0).Text = "42";
            GetCell(13, 0).Text = "43";
            GetCell(14, 0).Text = "44";
            GetCell(16, 0).Text = "45";
            GetCell(18, 0).Text = "58";

            GetCell(0, 13).Text = "57";
            GetCell(1, 13).Text = "56";
            GetCell(2, 13).Text = "55";
            GetCell(3, 13).Text = "54";
            GetCell(4, 13).Text = "53";
            GetCell(5, 13).Text = "52";
            GetCell(6, 13).Text = "51";
            GetCell(7, 13).Text = "64";
            GetCell(8, 13).Text = "63";
            GetCell(9, 13).Text = "62";
            GetCell(10, 13).Text = "61";
            GetCell(12, 13).Text = "74";
            GetCell(13, 13).Text = "75";
            GetCell(14, 13).Text = "76";
            GetCell(15, 13).Text = "77";

            GetCell(17, 13).Text = "12";
            GetCell(17, 14).Text = "13";
            GetCell(17, 15).Text = "14";
            GetCell(17, 16).Text = "15";
            GetCell(17, 17).Text = "16";
            GetCell(17, 18).Text = "17";
            GetCell(17, 19).Text = "18";
            GetCell(17, 20).Text = "19";
            GetCell(17, 21).Text = "20";
            GetCell(17, 22).Text = "21";
        }

        // Vult de 'Cells' in de tabel die de lijnnummers bijhouden
        // met de bijbehorende lijnnummers
        private void VulLijnnummers()
        {
            for (int spoor = 0; spoor < SporenArray.Length; spoor++)
            {
                for (int lijn = 0; lijn < Lijnen.Length - 1; lijn++)
                {
                    if (SporenArray[spoor] != null && SporenArray[spoor][0] != null)
                    {
                        for (int lijnSpoor = 1; lijnSpoor < Lijnen[lijn].Length; lijnSpoor++)
                        {
                            if (spoor == Lijnen[lijn][lijnSpoor])
                            {
                                SporenArray[spoor][0].Text = Convert.ToString(Lijnen[lijn][0]);
                            }
                        }
                    }
                }
            }
        }

        // Vult de tekst van de 'Cells' van de sectoren in de tabel
        private void VulSporen()
        {
            // Alle tramnummers uit de tabel halen
            for (int spoor = 0; spoor < SporenArray.Length; spoor++)
            {
                if (SporenArray[spoor] != null)
                {
                    for (int sector = 1; sector < SporenArray[spoor].Length; sector++)
                    {
                        if (SporenArray[spoor][sector] != null)
                        {
                            SporenArray[spoor][sector].Text = "";
                        }
                    }
                }
            }

            // De tabel opnieuw vullen met alle aanwezige trams
            foreach (Spoor sp in remise.Sporen)
            {
                foreach (Sector se in sp.Sectoren)
                {
                    if (se.Tram != null)
                    {
                        SporenArray[sp.Nummer][se.Nummer].Text = Convert.ToString(se.Tram.Nummer);
                    }
                }
            }
        }

        // Vult de tekst van de 'Cells' van de trams in de tabel
        public void VulTrams()
        {
            foreach (Spoor sp in remise.Sporen)
            {
                foreach (Sector se in sp.Sectoren)
                {
                    TableCell tc = SporenArray[sp.Nummer][se.Nummer];
                    tc.BackColor = Color.White;
                    if (se.Tram != null)
                    {
                        tc.Text = Convert.ToString(se.Tram.Nummer);
                    }
                    else if (se.Blokkade)
                    {
                        tc.BackColor = Color.Red;
                    }
                }
            }

            foreach (Reservering r in remise.Reserveringen)
            {
                SporenArray[r.Spoor.Nummer][SporenArray[r.Spoor.Nummer].Length - 1].BackColor = Color.Blue;
            }
        }

        // Sorteert een tram die binnen komt
        public void SorteerTram(Tram t)
        {
            // Controleert of de tram al in de remise staat
            foreach (Spoor sp in remise.Sporen)
            {
                foreach (Sector se in sp.Sectoren)
                {
                    if (se.Tram != null)
                    {
                        if (se.Tram.Nummer == t.Nummer && t.Status == "REMISE")
                        {
                            t.Status = "DIENST";
                            t.Beschikbaar = false;
                            UpdateTram(t);
                            se.Tram = null;
                            UpdateSector(se);
                            return;
                        }
                    }
                }
            }

            foreach (Lijn l in t.Lijnen)
            {
                int lijnNummer = l.Nummer;
                for (int lijn = 0; lijn < Lijnen.Length; lijn++)
                {
                    if (lijnNummer == Lijnen[lijn][0])
                    {
                        for (int spoor = 1; spoor < Lijnen[lijn].Length; spoor++)
                        {
                            // Pakt het eerstvolgende spoornummer dat bij de lijn
                            // van de meegegeven Tram hoort
                            int spoornummer = -1;
                            if (lijn == 2 && t.Nummer >= 2201 && t.Nummer <= 2204)
                            {
                                spoornummer = Lijnen[2][spoor];
                            }
                            else if (lijn == 3 && t.Nummer >= 901 && t.Nummer <= 920)
                            {
                                spoornummer = Lijnen[3][spoor];
                            }
                            else
                            {
                                spoornummer = Lijnen[lijn][spoor];
                            }

                            // Wanneer het eerstvolgende spoornummer is gevonden
                            if (spoornummer != -1)
                            {
                                // Zoekt het spoor in de list sporen
                                foreach (Spoor sp in remise.Sporen)
                                {
                                    if (sp.Nummer == spoornummer)
                                    {
                                        // Controleert of de eerstvolgende sector van dat spoor beschikbaar is
                                        foreach (Sector se in sp.Sectoren)
                                        {
                                            if (se.Beschikbaar && se.Tram == null && !se.Blokkade)
                                            {
                                                t.Status = "REMISE";
                                                t.Beschikbaar = true;
                                                UpdateTram(t);
                                                se.Tram = t;
                                                UpdateSector(se);
                                                return;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    // Wanneer de tram nergens terecht kan, wordt deze
                    // op een reservespoor geplaatst
                    if (lijn == Lijnen.Length - 2)
                    {
                        lijnNummer = Lijnen[Lijnen.Length - 1][0];
                    }
                }
            }
        }
    }
}