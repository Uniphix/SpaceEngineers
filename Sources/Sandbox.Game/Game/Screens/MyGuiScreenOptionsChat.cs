using Sandbox.Graphics.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage;
using VRage.Utils;
using VRageMath;

namespace Sandbox.Game.Gui
{
    public class MyGuiScreenOptionsChat : MyGuiScreenBase
    {
        static int CHATCOLORNUMBER = 3;

        Vector3I[] m_settingsOld, m_settings;

        /*
        MyGuiControlSlider m_hueSlider1, m_saturationSlider1, m_valueSlider1,
                           m_hueSlider2, m_saturationSlider2, m_valueSlider2,
                           m_hueSlider3, m_saturationSlider3, m_valueSlider3;

        MyGuiControlLabel m_hueLabel1, m_saturationLabel1, m_valueLabel1,
                          m_hueLabel2, m_saturationLabel2, m_valueLabel2,
                          m_hueLabel3, m_saturationLabel3, m_valueLabel3;

        MyGuiControlPanel m_colorControlPanel1,
                          m_colorControlPanel2,
                          m_colorControlPanel3;
                          */
        MyGuiControlSlider[] m_hueSliders, m_saturationSliders, m_valueSliders;
        MyGuiControlLabel[] m_hueLabels, m_saturationLabels, m_valueLabels;
        MyGuiControlPanel[] m_colorControlPanels;

        public MyGuiScreenOptionsChat()
            : base(new Vector2(0.5f, 0.5f), MyGuiConstants.SCREEN_BACKGROUND_COLOR, size: new Vector2(1000f, 1180f) / MyGuiConstants.GUI_OPTIMAL_SIZE)
        {
            EnabledBackgroundFade = true;

            m_settings = new Vector3I[3];
            m_settingsOld = new Vector3I[3];

            m_hueSliders = new MyGuiControlSlider[CHATCOLORNUMBER];
            m_valueSliders = new MyGuiControlSlider[CHATCOLORNUMBER];
            m_saturationSliders = new MyGuiControlSlider[CHATCOLORNUMBER];
            m_hueLabels = new MyGuiControlLabel[CHATCOLORNUMBER];
            m_saturationLabels = new MyGuiControlLabel[CHATCOLORNUMBER];
            m_valueLabels = new MyGuiControlLabel[CHATCOLORNUMBER];
            m_colorControlPanels = new MyGuiControlPanel[CHATCOLORNUMBER];

            RecreateControls(true);
        }

        public override void RecreateControls(bool constructor)
        {
            base.RecreateControls(constructor);

            int x = -460;
            int y = -450;

            AddCaption(MyCommonTexts.ScreenCaptionChatOptions);

            Controls.Add(new MyGuiControlLabel(position: new Vector2(x / 1600f, (y + 320 * 0) / 1200f), size: new Vector2(0.5f, 1f), text: MyTexts.GetString(MyCommonTexts.ChatTextColor1), originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER));
            Controls.Add(new MyGuiControlLabel(position: new Vector2(x / 1600f, (y + 320 * 1) / 1200f), size: new Vector2(0.5f, 1f), text: MyTexts.GetString(MyCommonTexts.ChatTextColor2), originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER));
            Controls.Add(new MyGuiControlLabel(position: new Vector2(x / 1600f, (y + 320 * 2) / 1200f), size: new Vector2(0.5f, 1f), text: MyTexts.GetString(MyCommonTexts.ChatTextColor3), originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER));
            //  Chat color 1
            for (int i = 0; i < CHATCOLORNUMBER; i++)
            {
                m_hueSliders[i] = new MyGuiControlSlider(
                    position: new Vector2(-x / 1600f, (y + 40 + 320 * i) / 1200f),
                    width: 0.25f,
                    minValue: 0,
                    maxValue: 320,
                    labelText: String.Empty,
                    labelDecimalPlaces: 0,
                    labelSpaceWidth: 50 / 1200f,
                    intValue: true,
                    originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER,
                    visualStyle: MyGuiControlSliderStyleEnum.Hue
                    );
                m_saturationSliders[i] = new MyGuiControlSlider(
                    position: new Vector2(-x / 1600f, (y + 130 + 320 * i) / 1200f),
                    width: 0.25f,
                    minValue: -100,
                    maxValue: 100,
                    defaultValue: 0,
                    labelText: String.Empty,
                    labelDecimalPlaces: 0,
                    labelSpaceWidth: 50 / 1200f,
                    intValue: true,
                    originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER
                    );
                m_valueSliders[i] = new MyGuiControlSlider(
                    position: new Vector2(-x / 1600f, (y + 220 + 320 * i) / 1200f),
                    width: 0.25f,
                    minValue: -100,
                    maxValue: 100,
                    defaultValue: 0,
                    labelText: String.Empty,
                    labelDecimalPlaces: 0,
                    labelSpaceWidth: 50 / 1200f,
                    intValue: true,
                    originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER
                    );

                m_hueSliders[i].ValueChanged += OnValueChange;
                m_saturationSliders[i].ValueChanged += OnValueChange;
                m_valueSliders[i].ValueChanged += OnValueChange;

                m_hueLabels[i] = new MyGuiControlLabel(position: new Vector2(-x / 1600f, (y + i * 320) / 1200f), text: String.Empty, originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER);
                m_saturationLabels[i] = new MyGuiControlLabel(position: new Vector2(-x / 1600f, (y + 90 + i * 320) / 1200f), text: String.Empty, originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER);
                m_valueLabels[i] = new MyGuiControlLabel(position: new Vector2(-x / 1600f, (y + 180 + i * 320) / 1200f), text: String.Empty, originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER);

                Controls.Add(new MyGuiControlLabel(position: new Vector2((-x - 60) / 1600f, (y + 320 * i) / 1200f), text: MyTexts.GetString(MyCommonTexts.ColorHue) + ":", originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER));
                Controls.Add(m_hueLabels[i]);
                Controls.Add(m_hueSliders[i]);
                Controls.Add(new MyGuiControlLabel(position: new Vector2((-x - 60 ) / 1600f, (y + 90 + 320 * i) / 1200f), text: MyTexts.GetString(MyCommonTexts.ColorSaturation) + ":", originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER));
                Controls.Add(m_saturationLabels[i]);
                Controls.Add(m_saturationSliders[i]);
                Controls.Add(new MyGuiControlLabel(position: new Vector2((-x - 60) / 1600f, (y + 180 + 320 * i) / 1200f), text: MyTexts.GetString(MyCommonTexts.ColorValue) + ":", originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER));
                Controls.Add(m_valueLabels[i]);
                Controls.Add(m_valueSliders[i]);
                m_colorControlPanels[i] = new MyGuiControlPanel(
                    size: new Vector2(0.3f, 0.03f),
                    position: new Vector2(((-x - 25) / 1600f), (y + 270 + i * 320) / 1200f), originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER);
                m_colorControlPanels[i].ColorMask = Color.White;
                m_colorControlPanels[i].BackgroundTexture = MyGuiConstants.TEXTURE_GUI_BLANK;

                Controls.Add(m_colorControlPanels[i]);
            }

            Controls.Add(new MyGuiControlButton(
                size: new Vector2(100f, 0.1f),
                position: new Vector2(-300 / 1600f, (y + 970) / 1200f),
                text: new StringBuilder(MyTexts.GetString(MyCommonTexts.ButtonReset)),
                onButtonClick: OnDefaultsClick));
            Controls.Add(new MyGuiControlButton(
                size: new Vector2(100f, 0.1f),
                position: new Vector2(0 / 1600f, (y + 970) / 1200f),
                text: new StringBuilder(MyTexts.GetString(MyCommonTexts.ButtonOK)),
                onButtonClick: OnOkClick));
            Controls.Add(new MyGuiControlButton(
                size: new Vector2(100f, 0.1f),
                position: new Vector2(300 / 1600f, (y + 970) / 1200f),
                text: new StringBuilder(MyTexts.GetString(MyCommonTexts.ButtonCancel)),
                onButtonClick: OnCancelClick));

            //  Update controls with values from config file
            if (constructor)
            {
                UpdateFromConfig(ref m_settingsOld);
                UpdateValues(m_settingsOld);
            }
            else
                UpdateValues(m_settings);

            CloseButtonEnabled = true;
            CloseButtonOffset = MakeXAndYEqual(new Vector2(-0.006f, 0.006f));
        }

        void UpdateFromConfig(ref Vector3I[] settings)
        {
            settings[0] = MySandboxGame.Config.ChatColor1;
            settings[1] = MySandboxGame.Config.ChatColor2;
            settings[2] = MySandboxGame.Config.ChatColor3;
        }

        void Save()
        {
            MySandboxGame.Config.ChatColor1 = m_settings[0];
            MySandboxGame.Config.ChatColor2 = m_settings[1];
            MySandboxGame.Config.ChatColor3 = m_settings[2];
            MySandboxGame.Config.Save();
        }

        void UpdateValues(Vector3I[] settings)
        {
            m_hueSliders[0].Value = settings[0].X;
            m_saturationSliders[0].Value = settings[0].Y;
            m_valueSliders[0].Value = settings[0].Z;
            m_hueSliders[1].Value = settings[1].X;
            m_saturationSliders[1].Value = settings[1].Y;
            m_valueSliders[1].Value = settings[1].Z;
            m_hueSliders[2].Value = settings[2].X;
            m_saturationSliders[2].Value = settings[2].Y;
            m_valueSliders[2].Value = settings[2].Z;
        }

        private void OnValueChange(MyGuiControlSlider sender)
        {
            int i = -1;
            for (int j = 0; j < CHATCOLORNUMBER; j++)
            {
                if (sender == m_valueSliders[j] || sender == m_hueSliders[j] || sender == m_saturationSliders[j])
                {
                    i = j;
                    break;
                }
            }

            if (i == -1)
                return;

            Color c = new Color();
            c = (new Vector3(m_hueSliders[i].Value / 360f, MathHelper.Clamp(m_saturationSliders[i].Value / 100f + 0.8f, 0f, 1f), MathHelper.Clamp(m_valueSliders[i].Value / 100f + 0.55f, 0f, 1f))).HSVtoColor();
            m_colorControlPanels[i].ColorMask = c;
            m_hueLabels[i].Text = m_hueSliders[i].Value.ToString() + "°";
            m_saturationLabels[i].Text = m_saturationSliders[i].Value.ToString();
            m_valueLabels[i].Text = m_valueSliders[i].Value.ToString();
            m_settings[i].X = (int)m_hueSliders[i].Value;
            m_settings[i].Y = (int)m_saturationSliders[i].Value;
            m_settings[i].Z = (int)m_valueSliders[i].Value;
        }

        public void OnOkClick(MyGuiControlButton sender)
        {
            //  Save values
            Save();

            CloseScreen();
        }

        public void OnDefaultsClick(MyGuiControlButton sender)
        {
            //  Revert to OLD values
            UpdateValues(m_settingsOld);
        }

        public void OnCancelClick(MyGuiControlButton sender)
        {
            //  Revert to OLD values
            UpdateValues(m_settingsOld);

            CloseScreen();
        }
        public override string GetFriendlyName()
        {
            return "Screen options Chat";
        }
    }
}
