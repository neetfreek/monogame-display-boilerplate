/************************************************
* Contain all references to global variables    * 
*************************************************/

namespace MonoGameDisplayBoilerplate
{
    public static class GlobalVariables
    {
        public const int WIDTH_VIRTUAL = 1920;
        public const int HEIGHT_VIRTUAL = 1080;
        public static int WidthActual;
        public static int HeightActual;

        public static float AspectActual
        {
            get
            {
                return WidthActual / (float)HeightActual;
            }
        }
        public static float AspectVirtual
        {
            get
            {
                return (WIDTH_VIRTUAL / (float)HEIGHT_VIRTUAL);
            }
        }
    }
}