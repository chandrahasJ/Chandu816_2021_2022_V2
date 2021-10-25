import 'package:flutter/material.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({Key? key}) : super(key: key);
  final String appName = "Online Shop";
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Column(
      children: [
        Image.asset("assets/images/login_image.png", fit: BoxFit.cover),
        const SizedBox(height: 20),
        const Text(
          "Login",
          style: TextStyle(fontSize: 28, fontWeight: FontWeight.bold),
        ),
        const SizedBox(height: 20),
        Padding(
          padding: const EdgeInsets.symmetric(vertical: 16.0, horizontal: 32.0),
          child: Column(
            children: [
              TextFormField(
                decoration: const InputDecoration(
                    hintText: "Enter Username", labelText: "Username"),
              ),
              TextFormField(
                  obscureText: true,
                  decoration: const InputDecoration(
                      hintText: "Enter Password", labelText: "Password"))
            ],
          ),
        ),
        const SizedBox(height: 20),
        ElevatedButton(
          child: const Text("Login"),
          style: TextButton.styleFrom(),
          onPressed: () {
            // ignore: avoid_print
            print("Login");
          },
        )
      ],
    ));
  }
}
