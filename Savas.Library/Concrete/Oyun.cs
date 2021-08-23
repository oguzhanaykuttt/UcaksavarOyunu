using Savas.Library.Enum;
using Savas.Library.Interface;
using System.Drawing;
using System;
using System.Windows.Forms;

namespace Savas.Library.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar
        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private TimeSpan _gecenSure;
        private readonly Panel _ucakSavarPanel;
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


        public Oyun(Panel ucakSavarPanel)
        {
            _ucakSavarPanel = ucakSavarPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        public void AtesEt()
        {
            throw new NotImplementedException();
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
            var ucaksavar = new ucaksavar(_ucakSavarPanel.Width)
            {
                Image = Image.FromFile(@"img\ucaksavar.png")
            };

            _ucakSavarPanel.Controls.Add(ucaksavar);
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            _gecenSureTimer.Stop();
        }

        public void UcaksavariHareketEttir(Yon yon)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
