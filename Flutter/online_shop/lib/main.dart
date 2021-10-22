import 'package:flutter/material.dart';
import 'package:online_shop/routes/app_route.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(primarySwatch: Colors.deepPurple),
      initialRoute: "/home",
      routes: Routes.buildRoutes(context: context),
    );
  }
}
