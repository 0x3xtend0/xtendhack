﻿using UnityEngine;
namespace xtendhack
{
  public class render : MonoBehaviour
  {
    public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

    public static Color Color
    {
      get { return GUI.color; }
      set { GUI.color = value; }
    }

    public static void draw_box(Vector2 position, Vector2 size, Color color, bool centered = true)
    {
      Color = color;
      draw_box(position, size, centered);
    }

    public static void draw_box(Vector2 position, Vector2 size, bool centered = true)
    {
      var upperLeft = centered ? position - size / 2f : position;
      GUI.DrawTexture(new Rect(position, size), Texture2D.whiteTexture, ScaleMode.StretchToFill);
      Color = Color.white;
    }

    public static void draw_string(Vector2 position, string label, Color color, bool centered = true)
    {
      Color = color;
      draw_string(position, label, centered);
    }

    public static void draw_string(Vector2 position, string label, bool centered = true)
    {
      var content = new GUIContent(label);
      var size = StringStyle.CalcSize(content);
      var upperLeft = centered ? position - size / 2f : position;
      GUI.Label(new Rect(upperLeft, size), content);
    }

    public static Texture2D lineTex;

    public static void draw_line(Vector2 pointA, Vector2 pointB, Color color, float width)
    {
      Matrix4x4 matrix = GUI.matrix;
      if (!lineTex)
        lineTex = new Texture2D(1, 1);

      Color color2 = GUI.color;
      GUI.color = color;
      float num = Vector3.Angle(pointB - pointA, Vector2.right);

      if (pointA.y > pointB.y)
        num = -num;

      GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width),
        new Vector2(pointA.x, pointA.y + 0.5f));
      GUIUtility.RotateAroundPivot(num, pointA);
      GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), lineTex);
      GUI.matrix = matrix;
      GUI.color = color2;
    }

    public static void draw_box(float x, float y, float w, float h, Color color, float thickness)
    {
      draw_line(new Vector2(x, y), new Vector2(x + w, y), color, thickness);
      draw_line(new Vector2(x, y), new Vector2(x, y + h), color, thickness);
      draw_line(new Vector2(x + w, y), new Vector2(x + w, y + h), color, thickness);
      draw_line(new Vector2(x, y + h), new Vector2(x + w, y + h), color, thickness);
    }

    public static void draw_box_outline(Vector2 Point, float width, float height, Color color, float thickness)
    {
      draw_line(Point, new Vector2(Point.x + width, Point.y), color, thickness);
      draw_line(Point, new Vector2(Point.x, Point.y + height), color, thickness);
      draw_line(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x + width, Point.y), color, thickness);
      draw_line(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x, Point.y + height), color,
        thickness);
    }
  }
}
