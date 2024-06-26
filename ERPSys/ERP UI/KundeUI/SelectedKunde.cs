﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class SelectedKunde(Kunde kunde) : Screen
    {
        public override string Title { get; set; } = "Selected Kunde";
        protected override void Draw()
        {
            Clear(this);

            ListPage<Kunde> selectedkunde = new();
            selectedkunde.Add(kunde);
            selectedkunde.AddColumn("Kundenummer", "KundeNummer");
            selectedkunde.AddColumn("Navn", "Navn");
            selectedkunde.AddColumn("Tlfnummer", "Tlfnummer");
            selectedkunde.AddColumn("Email", "Mail");
            selectedkunde.AddColumn("Adresse", nameof(kunde.Addresser));
            selectedkunde.AddColumn("Dato", "Dato");

            selectedkunde.Draw();

            ExitOnEscape();
        }
    }
}
