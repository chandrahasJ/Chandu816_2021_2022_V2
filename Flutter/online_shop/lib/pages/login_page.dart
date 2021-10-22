import 'package:flutter/material.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({Key? key}) : super(key: key);
  final String appName = "Online Shop";
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(appName),
      ),
      body: const Center(
        child: Text("Login Page"),
      ),
      drawer: const Drawer(),
    );
  }
}
