import 'package:flutter/material.dart';
import 'package:online_shop/routes/app_route.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final String appName = "Online Shop";
  String userName = "";
  bool changeButton = false;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SingleChildScrollView(
      child: Column(
        children: [
          Image.asset("assets/images/login_image.png", fit: BoxFit.cover),
          const SizedBox(height: 20),
          Text(
            "Welcome $userName",
            style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
          ),
          const SizedBox(height: 20),
          Padding(
            padding:
                const EdgeInsets.symmetric(vertical: 16.0, horizontal: 32.0),
            child: Column(
              children: [
                TextFormField(
                  decoration: const InputDecoration(
                      hintText: "Enter Username", labelText: "Username"),
                  onChanged: (value) {
                    userName = value;
                    setState(() {});
                  },
                ),
                TextFormField(
                    obscureText: true,
                    decoration: const InputDecoration(
                        hintText: "Enter Password", labelText: "Password"))
              ],
            ),
          ),
          const SizedBox(height: 20),
          InkWell(
            onTap: () async {
              setState(() {
                changeButton = true;
              });
              // ignore: avoid_print
              print("Login");
              await Future.delayed(Duration(seconds: 1));
              Navigator.pushNamed(context, CustomRoutes.homeRoute);
            },
            child: AnimatedContainer(
              duration: const Duration(seconds: 1),
              width: changeButton ? 50 : 150,
              height: 50,
              alignment: Alignment.center,
              child: changeButton
                  ? const Icon(Icons.done)
                  : const Text("Login",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.bold,
                          fontSize: 12)),
              decoration: BoxDecoration(
                  color: Colors.deepPurple,
                  borderRadius: BorderRadius.circular(changeButton ? 50 : 10)),
            ),
          )
          // ElevatedButton(
          //   child: const Text("Login"),
          //   style: TextButton.styleFrom(minimumSize: const Size(150, 40)),
          //   onPressed: () {
          //     // ignore: avoid_print
          //     print("Login");
          //     Navigator.pushNamed(context, CustomRoutes.homeRoute);
          //   },
          // )
        ],
      ),
    ));
  }
}
