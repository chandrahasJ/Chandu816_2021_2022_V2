import 'package:flutter/material.dart';
import 'package:velocity_x/velocity_x.dart';

class CartPage extends StatelessWidget {
  const CartPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: context.canvasColor,
      appBar: AppBar(
        backgroundColor: Colors.transparent,
        title: "Cart".text.make(),
      ),
      body: Column(
        children: [
          const Placeholder().p32().expand(),
          const Divider(),
          const CartTotal()
        ],
      ),
    );
  }
}

class CartTotal extends StatelessWidget {
  const CartTotal({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 200,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          // ignore: deprecated_member_use
          "Rs. 9999".text.xl5.color(context.theme.accentColor).make(),
          30.widthBox,
          ElevatedButton(
              // ignore: deprecated_member_use
              style: ButtonStyle(
                  backgroundColor:
                      // ignore: deprecated_member_use
                      MaterialStateProperty.all(context.theme.buttonColor)),
              onPressed: () => {
                    ScaffoldMessenger.of(context).showSnackBar(SnackBar(
                        content: "Buying not yet supported".text.white.make()))
                  },
              child: "Buy".text.xl5.white.make())
        ],
      ).p20(),
    );
  }
}
