using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Reflection;
//
//
namespace MORSE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //
        // Переменные  
        int Length = 0;
        int k1 = 0;
        int K = 0, L = 0;
        static public int Var = -1;
        Random rnd = new Random();
        private const int CS_DROPSHADOW = 0x00020000;
        Morse[] M = new Morse[55];      
        //
        // Вывод тени для формы
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP = base.CreateParams;
                CP.ClassStyle |= CS_DROPSHADOW;
                return CP;
            }
        }  
        //
        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Кнопка круглой формы
            GraphicsPath gp = new GraphicsPath();
            Graphics g = CreateGraphics();
            Rectangle SmallRect = BEnter.ClientRectangle;
            SmallRect.Inflate(-3, -3);
            gp.AddEllipse(SmallRect);
            BEnter.Region = new Region(gp);
            g.Dispose();
            // Кнопка круглой формы
            GraphicsPath gp1 = new GraphicsPath();
            Graphics g1 = CreateGraphics();
            Rectangle SmallRect1 = btnBegin.ClientRectangle;
            SmallRect1.Inflate(-4, -4);
            gp1.AddEllipse(SmallRect1);
            btnBegin.Region = new Region(gp1);
            g1.Dispose();
            // Кнопка круглой формы
            GraphicsPath gp2 = new GraphicsPath();
            Graphics g2 = CreateGraphics();
            Rectangle SmallRect2 = btnRed.ClientRectangle;
            SmallRect2.Inflate(-4, -4);
            gp2.AddEllipse(SmallRect2);
            btnRed.Region = new Region(gp2);
            g2.Dispose();
            //
            // Задание подсказок
            this.TT.SetToolTip(this.Ba, "А / A\n.-\nай-даа");
            this.TT.SetToolTip(this.Bb, "Б / B\n-...\nбаа-ки-те-кут");
            this.TT.SetToolTip(this.Bw, "В / W\n.--\nви-даа-лаа");
            this.TT.SetToolTip(this.Bg, "Г / G\n--.\nгаа-раа-жи");
            this.TT.SetToolTip(this.Bd, "Д / D\n-..\nдоо-ми-ки");
            this.TT.SetToolTip(this.Be, "Е / E\n.\nесть");
            this.TT.SetToolTip(this.Bv, "Ж / V\n...-\nжи-ви-те-таак");
            this.TT.SetToolTip(this.Bz, "З / Z\n--..\nзаа-каа-ти-ки");
            this.TT.SetToolTip(this.Bi, "И / I\n..\nи-ди");
            this.TT.SetToolTip(this.Bj, "Й / J\n.---\nи-краат-коо-ее");
            this.TT.SetToolTip(this.Bk, "К / K\n-.-\nкаак-же-таак");
            this.TT.SetToolTip(this.Bl, "Л / L\n.-..\nлу-наа-ти-ки");
            this.TT.SetToolTip(this.Bm, "М / M\n--\nмаа-маа");
            this.TT.SetToolTip(this.Bn, "Н / N\n-.\nноо-мер");
            this.TT.SetToolTip(this.Bo, "О / O\n---\nоо-коо-лоо");
            this.TT.SetToolTip(this.Bp, "П / P\n.--.\nпи-лаа-поо-ёт");
            this.TT.SetToolTip(this.Br, "Р / R\n.-.\nре-шаа-ет");
            this.TT.SetToolTip(this.Bs, "С / S\n...\nси-ни-е");
            this.TT.SetToolTip(this.Bt, "Т / T\n-\nтаак");
            this.TT.SetToolTip(this.Bu, "У / U\n..--\nу-нес-лоо");
            this.TT.SetToolTip(this.Bf, "Ф / F\n..-.\nфи-ли-моон-чик");
            this.TT.SetToolTip(this.Bh, "Х / H\n....\nхи-ми-чи-те");
            this.TT.SetToolTip(this.Bc, "Ц / C\n-.-.\nцаа-пли-наа-ши");
            this.TT.SetToolTip(this.Boo, "Ч / Ö\n---.\nчаа-шаа-тоо-нет");
            this.TT.SetToolTip(this.Bch, "Ш / CH\n----\nшаа-роо-ваа-рыы");
            this.TT.SetToolTip(this.Bq, "Щ / Q\n--.-\nщаа-ваам-не-шаа");
            this.TT.SetToolTip(this.Bnn, "Ъ / Ñ\n--.--\nтвёёр-дыый-не-мяяг-киий");
            this.TT.SetToolTip(this.By, "Ы / Y\n-.--\nыы-не-наа-доо");
            this.TT.SetToolTip(this.Bx, "Ь / X\n-..-\nтоо-мяг-кий-знаак");
            this.TT.SetToolTip(this.Bee, "Э / É\n..-..\nэ-ле-ктроо-ни-ки");
            this.TT.SetToolTip(this.Buu, "Ю / Ü\n..--\nю-ли-аа-наа");
            this.TT.SetToolTip(this.Baa, "Я / Ä\n.-.-\nя-маал-я-маал");
            this.TT.SetToolTip(this.Bdog, "@\n.--.-.\nсо-баа-каа-ку-саа-ет");
            this.TT.SetToolTip(this.B0, "0\n-----\nнооль-тоо-оо-коо-лоо");
            this.TT.SetToolTip(this.B1, "1\n.----\nи-тооль-коо-оо-днаа");
            this.TT.SetToolTip(this.B2, "2\n..---\nдве-не-хоо-роо-шоо");
            this.TT.SetToolTip(this.B3, "3\n...--\nтри-те-бе-маа-лоо");
            this.TT.SetToolTip(this.B4, "4\n....-\nче-тве-ри-те-каа");
            this.TT.SetToolTip(this.B5, "5\n.....\nпя-ти-ле-ти-е");
            this.TT.SetToolTip(this.B6, "6\n-....\nпоо-шес-ти-бе-ри");
            this.TT.SetToolTip(this.B7, "7\n--...\nдаа-даа-се-ме-ри");
            this.TT.SetToolTip(this.B8, "8\n---..\nвоо-сьмоо-гоо-и-ди");
            this.TT.SetToolTip(this.B9, "9\n----.\nвоо-доо-проо-воод-чик");
            this.TT.SetToolTip(this.Bdot, ".\n......\nто-чеч-ка-то-чеч-ка ");
            this.TT.SetToolTip(this.Bcom, ",\n.-.-.-\nкрю-чоок-крю-чоок-крю-чоок");
            this.TT.SetToolTip(this.Bcol, ":\n---...\nдвоо-ее-тоо-чи-е-ставь ");
            this.TT.SetToolTip(this.Bd_c, ";\n-.-.-\nтоо-чка-заа-пя-тоой");
            this.TT.SetToolTip(this.Bbra, "( / )\n-.--.-\nскоо-бку-стаавь-скоо-бку-стаавь");
            this.TT.SetToolTip(this.Bapp, "'\n.----.\nкрю-чоок-тыы-веерх-ниий-ставь");
            this.TT.SetToolTip(this.Bquo, "\"\n.-..-.\nка-выы-чки-ка-выы-чки");
            this.TT.SetToolTip(this.Bdash, "-\n-....-\nчёёр-точ-ку-мне-да-ваай");
            this.TT.SetToolTip(this.Bdev, "/\n-..-.\nдрообь-здесь-пред-стаавь-те");
            this.TT.SetToolTip(this.Bque, "?\n..--..\nэ-ти-воо-проо-си-ки");
            this.TT.SetToolTip(this.Bexc, "!\n--..--\nоо-наа-вос-кли-цаа-лаа");            
            //
            // Звуки и символы
            M[0] = new Morse('А', ".-");
            M[1] = new Morse('Б', "-...");
            M[2] = new Morse('В', ".--");
            M[3] = new Morse('Г', "--.");
            M[4] = new Morse('Д', "-..");
            M[5] = new Morse('Е', ".");
            M[6] = new Morse('Ж', "...-");
            M[7] = new Morse('З', "--..");
            M[8] = new Morse('И', "..");
            M[9] = new Morse('Й', ".---");
            M[10] = new Morse('К', "-.-");
            M[11] = new Morse('Л', ".-..");
            M[12] = new Morse('М', "--");
            M[13] = new Morse('Н', "-.");
            M[14] = new Morse('О', "---");
            M[15] = new Morse('П', ".--.");
            M[16] = new Morse('Р', ".-.");
            M[17] = new Morse('С', "...");
            M[18] = new Morse('Т', "-");
            M[19] = new Morse('У', "..--");
            M[20] = new Morse('Ф', "..-.");
            M[21] = new Morse('Х', "....");
            M[22] = new Morse('Ц', "-.-.");
            M[23] = new Morse('Ч', "---.");
            M[24] = new Morse('Ш', "----");
            M[25] = new Morse('Щ', "--.-");
            M[26] = new Morse('Ъ', "--.--");
            M[27] = new Morse('Ы', "-.--");
            M[28] = new Morse('Ь', "-..-");
            M[29] = new Morse('Э', "..-..");
            M[30] = new Morse('Ю', "..--");
            M[31] = new Morse('Я', ".-.-");
            M[32] = new Morse('@', ".--.-.");
            M[33] = new Morse('0', "-----");
            M[34] = new Morse('1', ".----");
            M[35] = new Morse('2', "..---");
            M[36] = new Morse('3', "...--");
            M[37] = new Morse('4', "....-");
            M[38] = new Morse('5', ".....");
            M[39] = new Morse('6', "-....");
            M[40] = new Morse('7', "--...");
            M[41] = new Morse('8', "---..");
            M[42] = new Morse('9', "----.");
            M[43] = new Morse('.', "......");
            M[44] = new Morse(',', ".-.-.-");
            M[45] = new Morse(':', "---...");
            M[46] = new Morse(';', "-.-.-");
            M[47] = new Morse('(', "-.--.-");      
            M[48] = new Morse('\'', ".----.");
            M[49] = new Morse('"', ".-..-.");
            M[50] = new Morse('-', "-....-");
            M[51] = new Morse('/', "-..-.");
            M[52] = new Morse('?', "..--..");
            M[53] = new Morse('!', "--..--");
            M[54] = new Morse(' ', "");  
            // 
            // Всплывающие подсказки
            this.TT.SetToolTip(this.RTBText, "Ограничение!\nНе более 100 символов!");
            this.TT.SetToolTip(this.BEnter, "Воспроизведение");
            //
            Control.CheckForIllegalCrossThreadCalls = false;
            //
            Var = 1;
        }        
        //
        // Воспроизведение
        private void BEnter_Click(object sender, EventArgs e)
        {
            string Text = RTBText.Text.ToUpper();
            Morse.Length = RTBText.Text.Length;
            Cursor = Cursors.WaitCursor;
            for (int i = 0; i < Text.Length; i++)
            {
                for (int j = 0; j < 55; j++)
                {
                    if (Text[i] == M[j].GetChar())
                    {
                        M[j].Sound();
                        break;
                    }
                }
            }
            Cursor = Cursors.Default;
        } 
        //
        // Ограничение количества символов
        private void RTBText_TextChanged(object sender, EventArgs e)
        {           
            if (RTBText.Text.Length > Length)
            {
                TSPBScale1.Step = RTBText.Text.Length - Length;
                TSPBScale1.PerformStep();
                Length = RTBText.Text.Length;
            }
            else
            {
                TSPBScale1.Step = RTBText.Text.Length - Length;
                TSPBScale1.ProgressBar.PerformStep();
                Length = RTBText.Text.Length;
            }
            TSSLInfo1.Text = "Количество символов: " + RTBText.Text.Length.ToString();
            //
            RTBPrint.Text = "";
            string Text = RTBText.Text.ToUpper();            
            for (int i = 0; i < Text.Length; i++)
            {
                for (int j = 0; j < 55; j++)
                {
                    if (Text[i] == M[j].GetChar())
                        M[j].Print(RTBPrint);
                }
            }  
        }
        //
        // Воспроизвести и изменить курсор
        private void SoundAndCurs(int i)
        {
            Cursor = Cursors.WaitCursor;
            M[i].Sound();
            Cursor = Cursors.Default;
        }
        // Буква А
        private void Ba_Click(object sender, EventArgs e)
        {
            SoundAndCurs(0);           
        }
        // Буква Б
        private void Bb_Click(object sender, EventArgs e)
        {
            SoundAndCurs(1);     
        }
        // Буква В
        private void Bw_Click(object sender, EventArgs e)
        {
            SoundAndCurs(2);     
        }
        // Буква Г
        private void Bg_Click(object sender, EventArgs e)
        {
            SoundAndCurs(3);     
        }
        // Буква Д
        private void Bd_Click(object sender, EventArgs e)
        {
            SoundAndCurs(4);     
        }
        // Буква Е
        private void Be_Click(object sender, EventArgs e)
        {
            SoundAndCurs(5);     
        }
        // Буква Ж
        private void Bv_Click(object sender, EventArgs e)
        {
            SoundAndCurs(6);     
        }
        // Буква З
        private void Bz_Click(object sender, EventArgs e)
        {
            SoundAndCurs(7);     
        }
        // Буква И
        private void Bi_Click(object sender, EventArgs e)
        {
            SoundAndCurs(8);     
        }
        // Буква Й
        private void Bj_Click(object sender, EventArgs e)
        {
            SoundAndCurs(9);     
        }
        // Буква К
        private void Bk_Click(object sender, EventArgs e)
        {
            SoundAndCurs(10);     
        }
        // Буква Л
        private void Bl_Click(object sender, EventArgs e)
        {
            SoundAndCurs(11);     
        }
        // Буква М
        private void Bm_Click(object sender, EventArgs e)
        {
            SoundAndCurs(12);     
        }
        // Буква Н
        private void Bn_Click(object sender, EventArgs e)
        {
            SoundAndCurs(13);     
        }
        // Буква О
        private void Bo_Click(object sender, EventArgs e)
        {
            SoundAndCurs(14);     
        }
        // Буква П
        private void Bp_Click(object sender, EventArgs e)
        {
            SoundAndCurs(15);     
        }
        // Буква Р
        private void Br_Click(object sender, EventArgs e)
        {
            SoundAndCurs(16);     
        }
        // Буква С
        private void Bs_Click(object sender, EventArgs e)
        {
            SoundAndCurs(17);     
        }
        // Буква Т
        private void Bt_Click(object sender, EventArgs e)
        {
            SoundAndCurs(18);     
        }
        // Буква У
        private void Bu_Click(object sender, EventArgs e)
        {
            SoundAndCurs(19);     
        }
        // Буква Ф
        private void Bf_Click(object sender, EventArgs e)
        {
            SoundAndCurs(20);     
        }
        // Буква Х
        private void Bh_Click(object sender, EventArgs e)
        {
            SoundAndCurs(21);     
        }
        // Буква Ц
        private void Bc_Click(object sender, EventArgs e)
        {
            SoundAndCurs(22);     
        }
        // Буква Ч
        private void Boo_Click(object sender, EventArgs e)
        {
            SoundAndCurs(23);     
        }
        // Буква Ш
        private void Bch_Click(object sender, EventArgs e)
        {
            SoundAndCurs(24);     
        }
        // Буква Щ
        private void Bq_Click(object sender, EventArgs e)
        {
            SoundAndCurs(25);     
        }
        // Буква Ъ
        private void Bnn_Click(object sender, EventArgs e)
        {
            SoundAndCurs(26);     
        }
        // Буква Ы
        private void By_Click(object sender, EventArgs e)
        {
            SoundAndCurs(27);     
        }
        // Буква Ь
        private void Bx_Click(object sender, EventArgs e)
        {
            SoundAndCurs(28);     
        }
        // Буква Э
        private void Bee_Click(object sender, EventArgs e)
        {
            SoundAndCurs(29);     
        }
        // Буква Ю
        private void Buu_Click(object sender, EventArgs e)
        {
            SoundAndCurs(30);     
        }
        // Буква Я
        private void Baa_Click(object sender, EventArgs e)
        {
            SoundAndCurs(31);     
        }
        // Символ @
        private void Bdog_Click(object sender, EventArgs e)
        {
            SoundAndCurs(32);     
        }
        // Цифра 0
        private void B0_Click(object sender, EventArgs e)
        {
            SoundAndCurs(33);     
        }
        // Цифра 1
        private void B1_Click(object sender, EventArgs e)
        {
            SoundAndCurs(34);     
        }
        // Цифра 2
        private void B2_Click(object sender, EventArgs e)
        {
            SoundAndCurs(35);     
        }
        // Цифра 3
        private void B3_Click(object sender, EventArgs e)
        {
            SoundAndCurs(36);     
        }
        // Цифра 4
        private void B4_Click(object sender, EventArgs e)
        {
            SoundAndCurs(37);     
        }
        // Цифра 5
        private void B5_Click(object sender, EventArgs e)
        {
            SoundAndCurs(38);     
        }
        // Цифра 6
        private void B6_Click(object sender, EventArgs e)
        {
            SoundAndCurs(39);     
        }
        // Цифра 7
        private void B7_Click(object sender, EventArgs e)
        {
            SoundAndCurs(40);     
        }
        // Цифра 8
        private void B8_Click(object sender, EventArgs e)
        {
            SoundAndCurs(41);     
        }
        // Цифра 9
        private void B9_Click(object sender, EventArgs e)
        {
            SoundAndCurs(42);     
        }
        // Символ .
        private void Bdot_Click(object sender, EventArgs e)
        {
            SoundAndCurs(43);     
        }
        // Символ ,
        private void Bcom_Click(object sender, EventArgs e)
        {
            SoundAndCurs(44);     
        }
        // Символ :
        private void Bcol_Click(object sender, EventArgs e)
        {
            SoundAndCurs(45);     
        }
        // Символ ;
        private void Bd_c_Click(object sender, EventArgs e)
        {
            SoundAndCurs(46);     
        }
        // Символ (
        private void Bbra_Click(object sender, EventArgs e)
        {
            SoundAndCurs(47);     
        }
        // Символ '
        private void Bapp_Click(object sender, EventArgs e)
        {
            SoundAndCurs(48);     
        }
        // Символ "
        private void Bquo_Click(object sender, EventArgs e)
        {
            SoundAndCurs(49);     
        }
        // Символ -
        private void Bdash_Click(object sender, EventArgs e)
        {
            SoundAndCurs(50);     
        }
        // Символ /
        private void Bdev_Click(object sender, EventArgs e)
        {
            SoundAndCurs(51);     
        }
        // Символ ?
        private void Bque_Click(object sender, EventArgs e)
        {
            SoundAndCurs(52);     
        }
        // Символ !
        private void Bexc_Click(object sender, EventArgs e)
        {
            SoundAndCurs(53);     
        }
        //
        // Начало проверки
        private void btnBegin_Click(object sender, EventArgs e)
        {
            tbAns.Focus();
            Morse.Length = 1;
            k1 = Environment.TickCount;
            Thread t = new Thread(Go);
            t.Start();   // Выполнить Go() в новом потоке.
            timT.Enabled = true;
        }
        //
        // Параллельно выводим на слух символы
        void Go() 
        {
            int b = rnd.Next(0, 31);
            M[b].Sound();
            tbAns.Text = lRight.Text =  "";
            while (Environment.TickCount - k1 <= 60000 && k1!=0)
            {                
                if (tbAns.Text.Length == 1)
                {
                    string str = tbAns.Text.ToUpper();
                    char Symb = str[0];
                    lRight.Text = M[b].GetChar().ToString();
                    if (Symb == M[b].GetChar())
                    {
                        K++;
                    }
                    L++;
                    tbAns.ReadOnly = false;
                    Go();
                }
            }
        }
        //
        // "Тикание" таймера
        private void timT_Tick(object sender, EventArgs e)
        {
            if (Environment.TickCount - k1 <= 60000)
            {
                lTime.Text = (59 - (Environment.TickCount - k1) / 1000).ToString();
            }
            else
            {
                lRes.Text = "За 60 секунд(ы) Вами было распознано " + K.ToString() + " символ(а)ов из " + L.ToString() + ".";
            }
        }
        //
        // Преждевременное окончание проверки
        private void btnRed_Click(object sender, EventArgs e)
        {
            lRes.Text = "За " + (((Environment.TickCount - k1) / 1000) + 1).ToString() + " секунд(ы) Вами было распознано " + K.ToString() + " символ(а)ов из " + L.ToString() + ".";
            k1 = 0;
            timT.Enabled = false;
        }
        //
        // Режим "Новичок"
        private void tsmNew_Click(object sender, EventArgs e)
        {
            tsmNew.Checked = true;
            tsmProf.Checked = false;
            Var = 2;
        }
        //
        // Режим "Профи"
        private void tsmProf_Click(object sender, EventArgs e)
        {
            tsmProf.Checked = true;
            tsmNew.Checked = false;
            Var = 1;
        }     
        //
        // Вывод справки
        private void tsmHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Эту и другие программы Вы сможете скачать на сайте www.sacret.ru", "© Sacret'11", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        //
        // Выход из приложения
        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        // При изменении вкладки
        private void TC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TC.SelectedTab == tabPage1)
            {
                TSSLInfo1.Visible = true;
                TSPBScale1.Visible = true;
            }
            if (TC.SelectedTab == tabPage2)
            {
                TSSLInfo1.Visible = false;
                TSPBScale1.Visible = false;
            }
        }
        //
        // При закрытии формы (чтоб не глючило^^)
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            k1 = 0;
            timT.Enabled = false;
        }       
       
    }
}
