using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale.Scripts.Backend
{
    public class Input
    {
        public static Input instance;

        public Input()
        {
            instance = this;
        }

        private bool interactKey;
        private bool cancelKey;
        private bool menuKey;

        public bool interact;
        public bool cancel;

        public Vector2 arrowKeys;

        public void UpdateInputs()
        {
            Interact();
            Cancel();
            ArrowKeys();
        }

        public void ArrowKeys()
        {
            float _x = 0;
            float _y = 0;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                _x += -1;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                _x += 1;

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                _y += -1;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                _y += 1;

            arrowKeys.X = _x;
            arrowKeys.Y = _y;
        }

        public void Interact()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                if (interactKey == false)
                {
                    interactKey = true;
                    interact = true;
                    return;
                }

                interact = false;
                return;
            }

            interact = false;
            interactKey = false;
        }
        public void Cancel()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                if (cancelKey == false)
                {
                    cancelKey = true;
                    cancel = true;
                    return;
                }

                cancel = false;
                return;
            }

            cancel = false;
            cancelKey = false;
        }
        public void Menu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                if (interactKey == false)
                {
                    interactKey = true;
                    interact = true;
                    return;
                }

                interact = false;
                return;
            }

            interactKey = false;
        }
    }
}
