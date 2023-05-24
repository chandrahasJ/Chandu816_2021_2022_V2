// ignore_for_file: file_names

import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:velocity_x/velocity_x.dart';

class CustomThemes {
  static ThemeData lightTheme(BuildContext context) => ThemeData(
      fontFamily: GoogleFonts.latoTextTheme().toString(),
      cardColor: Colors.white,
      canvasColor: creamColor,
      //brightness: Brightness.light,
      // ignore: deprecated_member_use
      buttonColor: darkBluishColor,
      appBarTheme: const AppBarTheme(
          color: Colors.white,
          elevation: 0.0,
          iconTheme: IconThemeData(color: Colors.black),
          toolbarTextStyle: TextStyle(color: Colors.black)),
      colorScheme: ColorScheme.fromSwatch(primarySwatch: Colors.deepPurple)
          .copyWith(secondary: bluishColor));

  static ThemeData darkTheme(BuildContext context) => ThemeData(
      // brightness: Brightness.dark,
      cardColor: Colors.white,
      canvasColor: creamColor,
      // ignore: deprecated_member_use
      buttonColor: darkBluishColor,
      fontFamily: GoogleFonts.latoTextTheme().toString(),
      appBarTheme: const AppBarTheme(
          color: Colors.white,
          elevation: 0.0,
          iconTheme: IconThemeData(color: Colors.black),
          toolbarTextStyle: TextStyle(color: Colors.black)),
      colorScheme: ColorScheme.fromSwatch(primarySwatch: Colors.deepPurple)
          .copyWith(secondary: Colors.white));

  //Colors
  static Color creamColor = const Color(0xfff5f5f5);
  static Color darkCreamColor = Vx.gray900;
  static Color bluishColor = const Color(0xff403b58);
  static Color darkBluishColor = Vx.indigo400;
}
