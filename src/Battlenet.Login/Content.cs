﻿using Battlenet.Common.Components;
using Battlenet.Login.Components;
using System.Windows.Input;

namespace Battlenet.Login
{
    public class Content : Component
    {
        private readonly ILayoutNavigator _layoutNavigator;

        public Content(ILayoutNavigator layoutNavigator)
        {
            this.Width = 364;
            this.Height = 815;
            this._layoutNavigator = layoutNavigator;
        }

        public override void RegionAttached(object argu = null)
        {
            Slate.WPF.RegionManager.Attach ("Root", this);
        }

        protected override void OnRender(object sender)
        {
            base.OnRender (sender);
        }
        protected override UIElement Build()
            => new Grid ()
                  .Background ("#15171e")
                  .Children (
                        new Border ()
                            .Margin (1)
                            .BorderBrush ("#36383e")
                            .BorderThickness (1)
                            .Child (
                                 new VStack ()
                                    .Children (
                                         new HStack ()
                                             .Right ()
                                             .Children
                                             (
                                                  new WindowButton (WindowButtonType.MINIAML)
                                                      .Background (Colors.Transparent, "#23252b")
                                                      .Foreground ("#4a4c51", "#ffffff")
                                                      .Height (22)
                                                      .Width (37),
                                                  new WindowButton (WindowButtonType.EXIT)
                                                      .Background (Colors.Transparent, "#dd1313")
                                                      .Foreground ("#4a4c51", "#ffffff")
                                                      .Height (22)
                                                      .Width (37)
                                             ),
                                         new Border ()
                                             .Padding (top: 10, left: 25, right: 26, bottom: 36)
                                             .Child (
                                                 new VStack ()
                                                     .Children (
                                                         new Image ()
                                                         {
                                                             Stretch = Stretch.None
                                                         }
                                                         .Source (PackUrlHelper.Load (this, "Resources/battlenet.png")),

                                                         new SettingButton ()
                                                             .Margin (top: 15, bottom: 10)
                                                             .Height (28)
                                                             .Width (28)
                                                             .Background ("#313238")
                                                             .Foreground (Colors.Transparent, "#3e4046")
                                                             .Right (),

                                                         UserTextBoxTemplate ("이메일 또는 휴대전화").Margin (bottom: 8),
                                                         UserTextBoxTemplate ("비밀번호").Margin (bottom: 12),

                                                         new SlateCheckBox ()
                                                            .BoxStyle (() => new SlateCheckBoxModel ()
                                                                                .BackColor ("#101117")
                                                                                .CheckColor ("#46a4fc")
                                                                                .Size (18)
                                                                                .Padding (1.2, 3)
                                                                                .CornerRadius (2)
                                                                                .Thickness (1.5)
                                                                                .BorderBrush ("#696b6f", "#7f8084"))
                                                            .Foreground ("#bebec0")
                                                            .FontSize (13)
                                                            .Content ("로그인 상태 유지하기"),

                                                         new SlateButton ()
                                                            .Margin (top: 30)
                                                            .Content ("로그인")
                                                            .FontSize (15)
                                                            .CornerRadius (5)
                                                            .Height (44)
                                                            .Foreground (Colors.White)
                                                            .Background ("#0074e0")
                                                            .BorderBrush(Colors.Transparent)
                                                            .BorderThickness (2)
                                                            .OnHover ((el) =>
                                                            {
                                                                ((SlateButton)el).BorderBrush.WithAnimation ("#47a6ff", 200);
                                                            })
                                                            .OnRelease ((el) =>
                                                            {
                                                                ((SlateButton)el).BorderBrush.WithAnimation (Colors.Transparent, 200);
                                                            })
                                                            .OnTapped (() =>
                                                            {
                                                                this._layoutNavigator.NavigateToAsync ("/Battlenet/Main/Home");
                                                            }),

                                                         new Grid ()
                                                            .Margin (topbottom: 26)
                                                            .Children (
                                                                new Slate.WPF.SlateDivider ()
                                                                    .Thickness (1)
                                                                    .Background ("#3f4147"),
                                                                new Label ()
                                                                    .Width (65)
                                                                    .Background ("#15171e")
                                                                    .Content ("또는")
                                                                    .FontSize (13)
                                                                    .Foreground ("#696b6f")
                                                                    .FontWeight (FontWeights.Bold)
                                                                    .HCenter ()
                                                                    .ContentHCenter ()
                                                            ),
                                                         new FlexPanel ()
                                                            .Height(126)
                                                            .Orientation (Orientation.Horizontal)
                                                            .Justify(JustifyContent.SpaceBetween)
                                                            
                                                            .Children(
                                                                SocialButton (Colors.White, "#cecece", IconPathSupport.Google),
                                                                SocialButton ("#3172d9", "#1860b7", IconPathSupport.Facebook),
                                                                SocialButton (Colors.White, "#cecece", IconPathSupport.Apple),
                                                                SocialButton ("#107c10", "#0a4f0a", IconPathSupport.Xbox),
                                                                SocialButton ("#0070cc", "#00439c", IconPathSupport.PlayStation),
                                                                SocialButton ("#e60012", "#b3000e", IconPathSupport.Nintendo),
                                                                SocialButton (Colors.White, "#cecece", IconPathSupport.Steam)
                                                             ),
                                                        new FlexPanel()
                                                            .Margin(top:35)
                                                            .Orientation(Orientation.Vertical)
                                                            .AlignContent (AlignContent.Center)
                                                            .Justify(JustifyContent.SpaceEvenly)
                                                            .Height(171)
                                                            .Children(
                                                                Text ("Battle.net 무료 회원 가입"),
                                                                Text ("로그인 문제 해결"),
                                                                Text ("탈퇴한 계정 복구"),
                                                                Text ("개인정보 처리방침")
                                                            )
                                                     )
                                             )
                                    )
                            )
                   );

        private SlateButton SocialButton(string background, string hoverBackground, Viewbox Content) => SocialButton (ColorTool.Get (background), ColorTool.Get (hoverBackground), Content);
        private SlateButton SocialButton(Color background, string hoverBackground, Viewbox Content) => SocialButton (background, ColorTool.Get (hoverBackground), Content);
        private SlateButton SocialButton(Color background, Color hoverBackground, Viewbox Content)
            => new SlateButton ()
                  .CornerRadius (5)
                  .Width (48)
                  .Height (48)
                  .Background (background)
                  .Content (
                      Content
                          .Height (18)
                          .Width (18)
                  )
                  .OnHover ((el) =>
                  {
                      ((SlateButton)el).Background.WithAnimation (hoverBackground, 200);
                  })
                  .OnRelease ((el) =>
                  {
                      ((SlateButton)el).Background.WithAnimation (background, 200);
                  });

        private TextBlock Text(string text)
            => new TextBlock ()
                    .Text (text)
                    .Cursor (Cursors.Hand)
                    .FontWeight (FontWeights.Bold)
                    .FontSize(15)
                    .Foreground ("#3a84f1")
                    .OnHover ((el) =>
                    {
                        ((TextBlock)el).Foreground.WithAnimation ("#5ca2f4");
                    })
                    .OnRelease ((el) =>
                    {
                        ((TextBlock)el).Foreground.WithAnimation ("#3a84f1");
                    });

        private SlateTextBox UserTextBoxTemplate(string waterMarkText)
            => new SlateTextBox ()
                    .WaterMarkText (waterMarkText)
                    .Background ("#101117")
                    .BorderBrush ("#696b6f")
                    .BorderThickness (1.5)
                    .CornerRadius (3)
                    .Height (33)
                    .FontSize (13)
                    .WaterMarkTextColor ("#88888b")
                    .OnHover ((el) =>
                    {
                        var tb = (Slate.WPF.SlateTextBox)el;
                        if (tb.IsKeyboardFocused)
                            return;

                        ((Slate.WPF.SlateTextBox)el).BorderBrush.WithAnimation ("#7f8084", 100);
                    })
                    .OnRelease ((el) =>
                    {
                        var tb = (Slate.WPF.SlateTextBox)el;
                        if (tb.IsKeyboardFocused)
                            return;

                        ((Slate.WPF.SlateTextBox)el).BorderBrush.WithAnimation ("#696b6f", 100);
                    })
                    .OnFocus ((tb) =>
                    {
                        ((Slate.WPF.SlateTextBox)tb).BorderBrush.WithAnimation ("#148eff", 100);
                    })
                    .OnLostFocus ((tb) =>
                    {
                        ((Slate.WPF.SlateTextBox)tb).BorderBrush.WithAnimation ("#101117", 100);
                    });
    }
}
