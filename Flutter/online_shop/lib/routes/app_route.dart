import 'package:flutter/material.dart';
import 'package:online_shop/pages/home_page.dart';
import 'package:online_shop/pages/login_page.dart';

class Routes {
  static Map<String, WidgetBuilder> buildRoutes(
      {required BuildContext context}) {
    var routes = {
      "/": (context) => const HomePage(),
      "/login": (context) => const LoginPage(),
      "/home": (context) => const HomePage()
    };
    return routes;
  }
}
