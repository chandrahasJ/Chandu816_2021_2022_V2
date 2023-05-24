import 'package:flutter/material.dart';
import 'package:online_shop/pages/cart_page.dart';
import 'package:online_shop/pages/home_page.dart';
import 'package:online_shop/pages/login_page.dart';

class CustomRoutes {
  static Map<String, WidgetBuilder> buildRoutes(
      {required BuildContext context}) {
    var routes = {
      "/": (context) => const LoginPage(),
      loginRoute: (context) => const LoginPage(),
      homeRoute: (context) => const HomePage(),
      cartRoute: (context) => const CartPage()
    };
    return routes;
  }

  static String homeRoute = "/home";
  static String loginRoute = "/login";
  static String productDetailsRoute = "/productDetails";
  static String cartRoute = "/cart";
}
