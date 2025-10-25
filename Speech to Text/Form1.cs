using System;
using System.Linq;
using System.Windows.Forms;
using System.Speech.Recognition;
namespace SpeechToText
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine recognizer;

        public Form1()
        {
            InitializeComponent();
            InitializeRecognizer();
        }

        private void InitializeRecognizer()
        {
            try
            {             
                var cultureInfo = new System.Globalization.CultureInfo("en-US");
                var recognizerInfo = SpeechRecognitionEngine.InstalledRecognizers()
                    .FirstOrDefault(r => r.Culture.Equals(cultureInfo));
                if (recognizerInfo == null)
                {
                    MessageBox.Show("Türkçe (tr-TR) konuşma paketi bulunamadı.\nLütfen Windows Ayarlar > Zaman ve Dil > Konuşma bölümünden Türkçe dil paketini yükleyin.", "Hata");
                    btnBaslat.Enabled = false;
                    btnDurdur.Enabled = false;
                    lblDurum.Text = "Türkçe paketi yüklü değil.";
                    return;
                }               
                recognizer = new SpeechRecognitionEngine(recognizerInfo);

                recognizer.SetInputToDefaultAudioDevice(); 
                recognizer.LoadGrammar(new DictationGrammar());
                recognizer.SpeechRecognized += Recognizer_SpeechRecognized; 
                recognizer.SpeechRecognitionRejected += Recognizer_SpeechRecognitionRejected; 
                btnDurdur.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tanıyıcı başlatılırken hata oluştu: {ex.Message}", "Kritik Hata");
            }
        }
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (recognizer == null) return;

            try
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                btnBaslat.Enabled = false;
                btnDurdur.Enabled = true;
                lblDurum.Text = "Dinliyorum...";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dinleme başlatılamadı: {ex.Message}");
            }
        }
        private void btnDurdur_Click(object sender, EventArgs e)
        {
            if (recognizer == null) return;
            recognizer.RecognizeAsyncStop();
            btnBaslat.Enabled = true;
            btnDurdur.Enabled = false;
            lblDurum.Text = "Durduruldu.";
        }
        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtSonuc.AppendText(e.Result.Text + Environment.NewLine);
            });
        }
        private void Recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblDurum.Text = "Anlaşılamadı. Tekrar deneyin.";
            });
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (recognizer != null)
            {
                recognizer.Dispose();
            }
        }
    }
}
