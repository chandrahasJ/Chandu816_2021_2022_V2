import 'package:flutter/material.dart';
import 'package:online_shop/routes/app_route.dart' show CustomRoutes;
import 'package:velocity_x/velocity_x.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final String appName = "Online Shop";
  String userName = "";
  bool changeButton = false;
  final _formKey = GlobalKey<FormState>();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SingleChildScrollView(
      child: Form(
        key: _formKey,
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
                    validator: (value) {
                      if (value!.isEmpty) {
                        return "Username cannot be empty";
                      }
                      return null;
                    },
                    decoration: const InputDecoration(
                        hintText: "Enter Username", labelText: "Username"),
                    onChanged: (value) {
                      userName = value;
                      setState(() {});
                    },
                  ),
                  TextFormField(
                      validator: (value) {
                        if (value!.isEmpty) {
                          return "Password cannot be empty";
                        } else if (value.length < 6) {
                          return "Password cannot be less than 6";
                        }
                        return null;
                      },
                      obscureText: true,
                      decoration: const InputDecoration(
                          hintText: "Enter Password", labelText: "Password"))
                ],
              ),
            ),
            const SizedBox(height: 20),
            Material(
              color: context.canvasColor,
              borderRadius: BorderRadius.circular(changeButton ? 50 : 10),
              child: InkWell(
                onTap: () => loginButton(context),
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
                ),
              ),
            )
          ],
        ),
      ),
    ));
  }

  loginButton(BuildContext context) async {
    if (_formKey.currentState!.validate()) {
      setState(() {
        changeButton = true;
      });
      // ignore: avoid_print
      print("Login");
      await Future.delayed(const Duration(seconds: 1));
      await Navigator.pushNamed(context, CustomRoutes.homeRoute);
      setState(() {
        changeButton = false;
      });
    }
  }
}
