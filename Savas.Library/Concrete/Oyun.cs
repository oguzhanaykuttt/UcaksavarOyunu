﻿using Savas.Library.Enum;
using Savas.Library.Interface;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Savas.Library.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar
        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private TimeSpan _gecenSure;
        private readonly Panel _ucakSavarPanel;
        private readonly Panel _savasAlaniPanel;
        private ucaksavar _ucaksavar;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        #endregion

        #region Olaylar
        public event EventHandler GecenSureDegisti;
        #endregion

        #region Ozellikler
        public bool DevamEdiyorMu { get; private set; }

        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;

                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Metotlar


        public Oyun(Panel ucakSavarPanel, Panel savasAlaniPanel)
        {
            _ucakSavarPanel = ucakSavarPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _savasAlaniPanel = savasAlaniPanel;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        public void AtesEt()
        {
            if (!DevamEdiyorMu) return;

            var mermi = new Mermi(_savasAlaniPanel.Size,_ucaksavar.Center);
            _mermiler.Add(mermi);
            _savasAlaniPanel.Controls.Add(mermi);
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;
            _gecenSureTimer.Start();
            UcakSavarOlustur();

        }

        private void UcakSavarOlustur()
        {
            _ucaksavar = new ucaksavar(_ucakSavarPanel.Width, _ucakSavarPanel.Size);

            _ucakSavarPanel.Controls.Add(_ucaksavar);
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            _gecenSureTimer.Stop();
        }

        public void UcaksavariHareketEttir(Yon yon)
        {
            if (!DevamEdiyorMu) return;
            _ucaksavar.HareketEttir(yon);
        }
        #endregion
    }
}
