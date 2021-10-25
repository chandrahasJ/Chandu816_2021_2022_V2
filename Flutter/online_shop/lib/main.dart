import 'package:flutter/material.dart';
import 'package:online_shop/routes/app_route.dart';
import 'package:google_fonts/google_fonts.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
          primarySwatch: Colors.deepPurple,
          fontFamily: GoogleFonts.latoTextTheme().toString()),
      initialRoute: "/home",
      routes: Routes.buildRoutes(context: context),
    );
  }
}
