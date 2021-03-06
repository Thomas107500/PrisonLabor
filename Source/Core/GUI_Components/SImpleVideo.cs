﻿using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PrisonLabor.Core.GUI_Components
{
    public class SimpleVideo
    {
        Texture2D[] frames;
        double framesPerSecond;

        public SimpleVideo(string texturesPath, double framesPerSecond)
        {
            var framesList = new List<Texture2D>();
            int iterator = 0;

            Texture2D texture;
            do
            {
                texture = ContentFinder<Texture2D>.Get($"{texturesPath}/{iterator++}", false);
                if (texture != null)
                    framesList.Add(texture);
            }
            while (texture != null);

            frames = framesList.ToArray();
            this.framesPerSecond = framesPerSecond;
        }

        public void OnGui(Rect rect)
        {
            if (frames.Length > 0)
                GUI.DrawTexture(rect, frames[(int)(Time.time * framesPerSecond) % frames.Length]);
            else
                Log.Warning("PrisonLabor Warning: no frames found in SimpleVideo");
        }
    }
}
