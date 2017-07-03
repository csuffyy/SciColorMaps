﻿namespace SciColorMaps
{
    /// <summary>
    /// 
    /// </summary>
    public class MirrorColorMap : ColorMap
    {
        /// <summary>
        /// Decorated colormap
        /// </summary>
        private ColorMap _colorMap;

        /// <summary>
        /// Recalculate palette colors each using one of 3 simple formulae
        /// </summary>
        private void MakeMirroredPalette()
        {
#if !RECTANGULAR
            var _prevPalette = _palette;

            // important: create new array for palette
            _palette = new byte[Palette.Resolution][];
            
            for (var i = 0; i < PaletteColors; i++)
            {
                var rgb = _prevPalette[PaletteColors - 1 - i];

                _palette[i] = new byte[3] { rgb[0], rgb[1], rgb[2] };
            }
#else
            var _prevPalette = _palette;

            // important: create new array for palette
            _palette = new byte[Palette.Resolution, 3];

            for (var i = 0; i < PaletteColors; i++)
            {
                _palette[i, 0] = _prevPalette[PaletteColors - 1 - i, 0];
                _palette[i, 1] = _prevPalette[PaletteColors - 1 - i, 1];
                _palette[i, 2] = _prevPalette[PaletteColors - 1 - i, 2];
            }
#endif
        }

        /// <summary>
        /// Constructor (also calls copy constructor of the base ColorMap class)
        /// 
        /// We gently substitute ordinary palette with grayscale palette
        /// 
        /// </summary>
        /// <param name="colorMap">Decorated colormap</param>
        public MirrorColorMap(ColorMap colorMap) : base(colorMap)
        {
            _colorMap = colorMap;

            MakeMirroredPalette();
        }
    }
}
