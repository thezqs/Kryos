namespace Core.Tools;

public static class Anim
{
    public static float Lerp(float a, float b, float w, bool isRotation = false)
    {
        if (isRotation)
        {
            float repeat = (b - a) % 360f;
            float shortAngle = (2f * repeat % 360f) - repeat;
            return a + shortAngle * w;
        }
        else return a + (b - a) * w;
    }

    public static Vector2 Lerp(Vector2 a, Vector2 b, float w)
    {
        return Vector2.Lerp(a, b, w);
    }

    public static Color4 Lerp(Color4 a, Color4 b, float w)
    {
        return new Color4(
            a.R + (b.R - a.R) * w,
            a.G + (b.G - a.G) * w,
            a.B + (b.B - a.B) * w,
            a.A + (b.A - a.A) * w
        );
    }
    
    public static float Ease(float s, float curve)
    {
        s = Math.Clamp(s, 0, 1);

        // curve > 0: Casos estándar (In, Out, Linear)
        if (curve > 0f)
        {
            if (curve < 1f)
            {
                // Entre 0 y 1 → Ease-In (Aceleración)
                return MathF.Pow(s, 1f / curve);
            }
            if (curve > 1f)
            {
                // Mayor a 1 → Ease-Out (Desaceleración)
                return 1f - MathF.Pow(1f - s, curve);
            }

            // 1 → Lineal (Sin cambios)
            return s;
        }

        // curve < 0: Casos combinados (In-Out / Out-In)
        if (curve < 0f)
        {
            curve = -curve;

            if (s < 0.5f)
            {
                // Primera mitad de la animación (Ease-In)
                return MathF.Pow(s * 2f, curve) * 0.5f;
            }
            else
            {
                // Segunda mitad de la animación (Ease-Out)
                return (1f - MathF.Pow(1f - (s - 0.5f) * 2f, curve)) * 0.5f + 0.5f;
            }
        }
        // 0f Es modo boleano. O es 1, o es 0.
        return s == 1f ? 1f : 0f;
    }
}
