import 'package:flutter/material.dart';
import 'package:online_shop/widgets/custom_drawer.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);
  final String appName = "Online Shop";
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(appName),
      ),
      body: Center(
        child: Text("Welcome to $appName"),
      ),
      drawer: const CustomDrawer(),
    );
  }
}
