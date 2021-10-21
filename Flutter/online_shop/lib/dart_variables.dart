import 'package:flutter/material.dart';

// ignore: must_be_immutable
class DartVariables extends StatelessWidget {
  int days = 0;
  double height = 5.7;
  String myName = "ChanduP";
  bool isWoke = true;
  num temperture = 5.8; //Takes both integer and double

  static const double pi = 3.14; //const this data cannot be changed.
  //final this data type will take memory after it will be used.
  final String checkData = "100";

  var data = "Any data can be used it is same as c# var";

  DartVariables({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container();
  }
}
