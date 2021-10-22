import 'package:flutter/material.dart';

class FunctionTrails extends StatelessWidget {
  const FunctionTrails({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    functionParameterLess();
    function101();
    funtion102(isCheck: true);
    int temp = function103(temp: 1000);
    // ignore: avoid_print
    print(temp);
    return Container();
  }

  void functionParameterLess() {}

  void function101({bool isCheck = true}) {}

  void funtion102({required bool isCheck, int temp = 1000}) {}

  int function103({required int temp}) {
    return temp;
  }
}
