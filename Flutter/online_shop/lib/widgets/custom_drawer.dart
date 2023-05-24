import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class CustomDrawer extends StatelessWidget {
  const CustomDrawer({Key? key}) : super(key: key);

  final String imageUrl =
      "https://yt3.ggpht.com/ytc/AKedOLTt2Ww-uwIxcqv1Nx0MBzAR6ZlPma0kTDGuGEUvtw=s900-c-k-c0x00ffffff-no-rj";
  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: Container(
        color: Colors.deepPurple,
        child: ListView(
          padding: EdgeInsets.zero,
          children: [
            DrawerHeader(
                margin: EdgeInsets.zero,
                child: UserAccountsDrawerHeader(
                  margin: EdgeInsets.zero,
                  accountEmail: const Text("Chandrahas Poojari"),
                  accountName: const Text("poojari.chandrahas@gmail.com"),
                  currentAccountPicture: CircleAvatar(
                    backgroundImage: NetworkImage(imageUrl),
                  ),
                )),
            const ListTile(
              leading: Icon(CupertinoIcons.home, color: Colors.white),
              title: Text("Home",
                  textScaleFactor: 1.2, style: TextStyle(color: Colors.white)),
            ),
            const ListTile(
              leading:
                  Icon(CupertinoIcons.profile_circled, color: Colors.white),
              title: Text("Profile",
                  textScaleFactor: 1.2, style: TextStyle(color: Colors.white)),
            ),
            const ListTile(
              leading: Icon(CupertinoIcons.mail, color: Colors.white),
              title: Text("Contact Us",
                  textScaleFactor: 1.2, style: TextStyle(color: Colors.white)),
            )
          ],
        ),
      ),
    );
  }
}
