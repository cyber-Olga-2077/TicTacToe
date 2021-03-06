﻿using SFML.Graphics;
using SFML.System;
using System;
using TicTacToe.Game.Actors;
using TicTacToe.Utility;

namespace TicTacToe.Game.GUI.RenderObjects
{
    public enum TextPosition
    {
        Start,
        Middle,
        End
    }

    internal class AlignedRenderText : IRenderObject
    {
        public Position ContainerPosition;
        public Vector2f Margins;

        private TextPosition HorizontalPosition;
        private TextPosition VerticalPosition;

        public float FontSize { get; protected set; }
        public string Text { get; set; }
        protected IRenderable Actor { get; set; }
        public Font Font;
        private Color Color { get; set; }

        public AlignedRenderText(Position containerPosition, Vector2f margins, int fontSize, TextPosition horizontalPosition, TextPosition verticalPosition, IRenderable actor, Color color, string text)
        {
            ContainerPosition = containerPosition;
            Margins = margins;
            HorizontalPosition = horizontalPosition;
            VerticalPosition = verticalPosition;

            Actor = actor;

            Color = color;
            Text = text;
            Font = new Font("assets/fonts/Lato-Regular.ttf");

            if (fontSize != 0)
            {
                SetFontSize(fontSize);
            }
            else
            {
                FontSize = 1;
            }
        }

        public void SetFontSize(int height)
        {
            FontSize = height;
        }

        public IRenderable GetActor()
        {
            return Actor;
        }

        public Transformable GetShape()
        {
            SFML.Graphics.Text text = new SFML.Graphics.Text(Text, Font, (uint)FontSize)
            {
                FillColor = Color,
            };

            text.Position = CalculatePosition(text);

            return text;
        }

        public void SetSize(int width, int height)
        {
            SetFontSize(height);
        }

        public void SetPosition(Position position)
        {
            ContainerPosition = position;
        }

        public void SetColor(Color color)
        {
            Color = color;
        }

        public bool IsPointInside(int x, int y)
        {
            return false;
        }

        private Vector2f CalculatePosition(SFML.Graphics.Text textElement)
        {
            float x = 0;
            float y = 0;

            switch (HorizontalPosition)
            {
                case TextPosition.Start:
                    x = ContainerPosition.X + Margins.X;
                    break;

                case TextPosition.Middle:
                    x = ContainerPosition.X + ContainerPosition.Width / 2 - textElement.GetGlobalBounds().Width / 2;
                    break;

                case TextPosition.End:
                    x = ContainerPosition.X + ContainerPosition.Width - textElement.GetGlobalBounds().Width - Margins.X;
                    break;
            }

            switch (VerticalPosition)
            {
                case TextPosition.Start:
                    y = ContainerPosition.Y + Margins.Y;
                    break;

                case TextPosition.Middle:
                    y = ContainerPosition.Y + ContainerPosition.Height / 2 - textElement.CharacterSize / 1.5F;
                    break;

                case TextPosition.End:
                    y = ContainerPosition.Y + ContainerPosition.Height - textElement.GetGlobalBounds().Height - Margins.Y;
                    break;
            }

            return new Vector2f((float)Math.Ceiling(x), (float)Math.Floor(y));
        }
    }
}