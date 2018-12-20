﻿using System;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

public static class Extend {

    private const string EmptyString = "####";
    public const bool INVALID_BOOL = false;
    public const sbyte INVALID_INT8 = sbyte.MaxValue;
    public const short INVALID_INT16 = Int16.MaxValue;
    public const int INVALID_INT32 = Int32.MaxValue;
    public const long INVALID_INT64 = Int64.MaxValue;
    public const float INVALID_FLOAT = -1.0f;
    public const double INVALID_DOUBLE = -1.0;
    public const string INVALID_STRING = "";
    public static string GetMemory(this long by) {
        return Scorpio.Commons.Util.GetMemory(by);
    }
    public static string GetLineName(this int line) {
        return Scorpio.Commons.Util.GetExcelColumn(line);
    }
    public static bool IsEmptyString(this string str) {
        return str == EmptyString || string.IsNullOrWhiteSpace(str);
    }
    public static bool ToBoolean(this string value) {
        if (value.IsEmptyString()) { return INVALID_BOOL; }
        switch (value.ToLower()) {
            case "1":
            case "true":
            case "yes":
                return true;
            case "0":
            case "false":
            case "no":
                return false;
            default:
                throw new Exception("字符串不能转换为bool " + value);
        }
    }
    public static sbyte ToInt8(this string value) {
        return value.IsEmptyString() ? INVALID_INT8 : Convert.ToSByte(value);
    }
    public static short ToInt16(this string value) {
        return value.IsEmptyString() ? INVALID_INT16 : Convert.ToInt16(value);
    }
    public static int ToInt32(this string value) {
        return value.IsEmptyString() ? INVALID_INT32 : Convert.ToInt32(value);
    }
    public static long ToInt64(this string value) {
        return value.IsEmptyString() ? INVALID_INT64 : Convert.ToInt64(value);
    }
    public static float ToFloat(this string value) {
        return value.IsEmptyString() ? INVALID_FLOAT : Convert.ToSingle(value);
    }
    public static double ToDouble(this string value) {
        return value.IsEmptyString() ? INVALID_DOUBLE : Convert.ToDouble(value);
    }
    public static string GetCellString(this ICell cell) {
        if (cell == null) return "";
        cell.SetCellType(CellType.String);
        return cell.StringCellValue;
    }
    public static void SetCellString(this ICell cell, string value) {
        if (cell == null) return;
        cell.SetCellType(CellType.String);
        cell.SetCellValue(value);
    }
}