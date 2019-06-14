<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<title>明日方舟抽卡模拟器</title>

</head>
<body>
<h1 align="center">明日方舟抽卡模拟器</h1>
<h2 align="center">UP池：塞雷亚,闪灵
<div>
<form>

<div align="center">
  <input type="button" value="抽卡" onclick="clickButton()" style="height:60px;width:60px;"/>
  </div>
  <div align="center">
  <input type="button" value="清空" onclick="cleanup()" style="height:60px;width:60px;"/></div>
</form>
</div>
<body background="http://p5.qhimg.com/dr/1280__/t01459034aceb84f904.png"
style=" background-repeat:no-repeat ;
background-size:100% 100%;
background-attachment: fixed;"
>
<p1 id=demo><br>
</p1>

<script>
var saileiya="<img style='border:5px solid #EEEE00' src='http://p2.qhimg.com/dr/150__/t012dd0eaddfe75600b.png' width='50' height='50'>"
var xiaomianyang="<img style='border:5px solid #EEEE00' src='http://p2.qhimg.com/dr/150__/t01487774e7e38e5c1e.png' width='50' height='50'>"
var nengtianshi="<img style='border:5px solid #EEEE00' src='http://p7.qhimg.com/dr/150__/t019c37b9d9b5ea1a5c.png' width='50' height='50'>"
var xiaohuolong="<img style='border:5px solid #EEEE00' src='http://p8.qhimg.com/dr/150__/t01665df6d2f7ffdc66.png' width='50' height='50'>"
var daimaowang="<img style='border:5px solid #EEEE00' src='http://p3.qhimg.com/dr/150__/t01c502355dfb308d1d.png' width='50' height='50'>"
var yinghui="<img style='border:5px solid #EEEE00' src='http://p8.qhimg.com/dr/150__/t0198c1592aaa1d557b.png 'width='50' height='50'>"
var sikadi="<img style='border:5px solid #EEEE00' src='http://p8.qhimg.com/dr/150__/t019b00ae321487781f.png' width='50' height='50'>"
var xingxiong="<img style='border:5px solid #EEEE00' src='http://p5.qhimg.com/dr/150__/t01ed97940a904fe79d.png' width='50' height='50'>"
var yeying="<img style='border:5px solid #EEEE00' src='http://p7.qhimg.com/dr/150__/t01a371828406834314.png' width='50' height='50'>"
var shanling="<img style='border:5px solid #EEEE00' src='http://p0.qhimg.com/dr/150__/t01530756367f2cee1c.png' width='50' height='50'>"
var jiege="<img style='border:5px solid #EEEE00' src='http://p5.qhimg.com/dr/150__/t01d02ff918590a9f9d.png' width='50' height='50'>"
/*
SR
*/
var yunxing="<img style='border:5px solid #FF0000' src='http://p1.qhimg.com/dr/150__/t01076e24d8da6ffe44.png' width='50' height='50'>"
var landu="<img style='border:5px solid #FF0000' src='http://p7.qhimg.com/dr/150__/t01c2d752ccca46acc3.png' width='50' height='50'>"
var puluo="<img style='border:5px solid #FF0000' src='http://p4.qhimg.com/dr/150__/t012ac05476f3e84b0b.png' width='50' height='50'>"
var baijin="<img style='border:5px solid #FF0000' src='http://p5.qhimg.com/dr/150__/t018f36f2056cfb3753.png' width='50' height='50'>"
var shoulin="<img style='border:5px solid #FF0000' src='http://p2.qhimg.com/dr/150__/t01fe9befb72c5fa20d.png' width='50' height='50'>"
var yemo="<img style='border:5px solid #FF0000' src='http://p3.qhimg.com/dr/150__/t019da149dea89cb03d.png' width='50' height='50'>"
var tianhuo="<img style='border:5px solid #FF0000' src='http://p1.qhimg.com/dr/150__/t01f3769228747d1ffd.png' width='50' height='50'>"
var lindong="<img style='border:5px solid #FF0000' src='http://p0.qhimg.com/dr/150__/t01e318e95d7934d59a.png' width='50' height='50'>"
var deke="<img style='border:5px solid #FF0000' src='http://p3.qhimg.com/dr/150__/t01fec5ad1cac71ea8f.png' width='50' height='50'>"
var youling="<img style='border:5px solid #FF0000' src='http://p1.qhimg.com/dr/150__/t0144bc8bb6c3b82fe5.png' width='50' height='50'>"
var fulan="<img style='border:5px solid #FF0000' src='http://p1.qhimg.com/dr/150__/t017ddbdaf24f97c8d3.png' width='50' height='50'>"
var lapu="<img style='border:5px solid #FF0000' src='http://p4.qhimg.com/dr/150__/t011d0fc4cbc5d0510c.png' width='50' height='50'>"
var leishe="<img style='border:5px solid #FF0000' src='http://p4.qhimg.com/dr/150__/t019d88ea4258977505.png' width='50' height='50'>"
var linguang="<img style='border:5px solid #FF0000' src='http://p1.qhimg.com/dr/150__/t018f43603ad070b485.png' width='50' height='50'>"
var kesong="<img style='border:5px solid #FF0000' src='http://p8.qhimg.com/dr/150__/t015cb4a3a66c02d6ca.png' width='50' height='50'>"
var huafa="<img style='border:5px solid #FF0000' src='http://p3.qhimg.com/dr/150__/t011d33ebbf64a2556d.png' width='50' height='50'>"
var hemo="<img style='border:5px solid #FF0000' src='http://p9.qhimg.com/dr/150__/t01ae211dc87d436afa.png' width='50' height='50'>"
var baimian="<img style='border:5px solid #FF0000' src='http://p4.qhimg.com/dr/150__/t01c30f9d9e22ac92c6.png' width='50' height='50'>"
var meier="<img style='border:5px solid #FF0000' src='http://p0.qhimg.com/dr/150__/t012c060bf0c7065917.png' width='50' height='50'>"
var sora="<img style='border:5px solid #FF0000' src='http://p2.qhimg.com/dr/150__/t01fcbb67562ce88b0b.png' width='50' height='50'>"
var zhenli="<img style='border:5px solid #FF0000' src='http://p8.qhimg.com/dr/150__/t01afb8dd75627ff672.png' width='50' height='50'>"
var chuxue="<img style='border:5px solid #FF0000' src='http://p3.qhimg.com/dr/150__/t0143b62127bdc254d6.png' width='50' height='50'>"
var shitie="<img style='border:5px solid #FF0000' src='http://p7.qhimg.com/dr/150__/t012e01eaf0e6fda37a.png' width='50' height='50'>"
var yaxin="<img style='border:5px solid #FF0000' src='http://p6.qhimg.com/dr/150__/t011f882e0c430d51a2.png' width='50' height='50'>"
var shixie="<img style='border:5px solid #FF0000' src='http://p9.qhimg.com/dr/150__/t011893c426074ce802.png' width='50' height='50'>"
var hong="<img style='border:5px solid #FF0000' src='http://p5.qhimg.com/dr/150__/t01f045b4be633c7b14.png' width='50' height='50'>"
/*
R
*/
var liuxing="<img src='http://p0.qhimg.com/dr/150__/t01269411046deb1bc2.png' width='50' height='50'>"
var jiexi="<img src='http://p6.qhimg.com/dr/150__/t014605bfade2a6cba7.png' width='50' height='50'>"
var baixue="<img src='http://p5.qhimg.com/dr/150__/t0118b51415939706cc.png' width='50' height='50'>"
var yuanshan="<img src='http://p1.qhimg.com/dr/150__/t016689d1382b22924d.png' width='50' height='50'>"
var qingdaofu="<img src='http://p1.qhimg.com/dr/150__/t01c236754d42051e9f.png' width='50' height='50'>"
var hongdou="<img src='http://p8.qhimg.com/dr/150__/t01f1dfa4fb29b3fd6e.png' width='50' height='50'>"
var musi="<img src='http://p1.qhimg.com/dr/150__/t0119f87682f7d8917b.png' width='50' height='50'>"
var shuangye="<img src='http://p2.qhimg.com/dr/150__/t019b6f499396ff0406.png' width='50' height='50'>"
var chanwan="<img src='http://p2.qhimg.com/dr/150__/t010f3fc472b4900b95.png' width='50' height='50'>"
var dubin="<img src='http://p2.qhimg.com/dr/150__/t0115aa310877b07f77.png' width='50' height='50'>"
var liefeng="<img src='http://p9.qhimg.com/dr/150__/t01ad54a8ac984b9946.png' width='50' height='50'>"
var gumi="<img src='http://p6.qhimg.com/dr/150__/t012b8712083684ebe9.png' width='50' height='50'>"
var shepi="<img src='http://p2.qhimg.com/dr/150__/t012603ad559fe16630.png' width='50' height='50'>"
var tiaoxiang="<img src='http://p0.qhimg.com/dr/150__/t01a216782933830c81.png' width='50' height='50'>"
var dilin="<img src='http://p6.qhimg.com/dr/150__/t01881bc81c3337410c.png' width='50' height='50'>"
var shenhai="<img src='http://p4.qhimg.com/dr/150__/t01ede14c4b4255d441.png' width='50' height='50'>"
var ansuo="<img src='http://p9.qhimg.com/dr/150__/t0114386af7b5ab089b.png' width='50' height='50'>"
var axiao="<img src='http://p4.qhimg.com/dr/150__/t018f48444dc04bab7f.png' width='50' height='50'>"
var li="<img src='http://p0.qhimg.com/dr/150__/t01c035725472bf99fb.png' width='50' height='50'>"
/*
N
*/
var keluo="<img src='http://p1.qhimg.com/dr/150__/t01c1bfbb9233daccd4.png' width='50' height='50'>"
var ande="<img src='http://p0.qhimg.com/dr/150__/t016604e81077ccb1f6.png' width='50' height='50'>"
var kongbao="<img src='http://p6.qhimg.com/dr/150__/t0160320f7e19905e9c.png' width='50' height='50'>"
var shidu="<img src='http://p4.qhimg.com/dr/150__/t0179edfff56ec456df.png' width='50' height='50'>"
var yanrong="<img src='http://p3.qhimg.com/dr/150__/t01651c49953d8bb071.png' width='50' height='50'>"
var xiangcao="<img src='http://p4.qhimg.com/dr/150__/t01f064d97af7b444a7.png' width='50' height='50'>"
var linyu="<img src='http://p0.qhimg.com/dr/150__/t012205ad0f9ddadd75.png' width='50' height='50'>"
var feng="<img src='http://p6.qhimg.com/dr/150__/t0112ded5e2c886e2ed.png' width='50' height='50'>"
var jiansheng="<img src='http://p1.qhimg.com/dr/150__/t01e1fe82f378388ef3.png' width='50' height='50'>"
var yuejian="<img src='http://p5.qhimg.com/dr/150__/t01e4af18cc68307213.png' width='50' height='50'>"
var migelu="<img src='http://p3.qhimg.com/dr/150__/t01c064f122e000a7b7.png' width='50' height='50'>"
var kati="<img src='http://p9.qhimg.com/dr/150__/t01a11167e7b570c380.png' width='50' height='50'>"
var furong="<img src='http://p7.qhimg.com/dr/150__/t01cc057775b9b8d2ea.png' width='50' height='50'>"
var ansai="<img src='http://p7.qhimg.com/dr/150__/t013ee228947b0d0e66.png' width='50' height='50'>"
var zilan="<img src='http://p2.qhimg.com/dr/150__/t016c94f9edd3891f30.png' width='50' height='50'>"



var geta
var decide
var a
var b
var c=0
var i=0
var index=0
var consta
var d
var upssr
var decideupssr
var upsr
var decideupsr
var sr
var r
var n
var num6=0
var num5=0
var num4=0

function drawCard(){
geta=Math.floor(Math.random()*100)
if(geta>=0&&geta<=1+i*2){
	decide=0;
	}
else 
    {
	decide=1;
	}
if(decide==1){
	   index++;	
		}
	 else{
		index=0; 
		 }
if(index>=50){
	i++;
	}
else{
	
     i=0;
	}


}

function drawNormal(){
	consta=Math.floor(Math.random()*98)
	
	if(consta>=0&&consta<=7){
	 drawSrcard();
	}
	if(consta>7&&consta<=57){
	 drawRcard();
	}
	if(consta>57&&consta<=97){
	 drawNcard();
	}
	}




function drawSsrcard(){
upssr=Math.floor(Math.random()*2);
num6++;

if(upssr==0){
	num4++
	decideupssr=Math.floor(Math.random()*2);
	switch(decideupssr){
	
	case 0:
document.getElementById("demo").innerHTML +=saileiya;
break;
	
	case 1:
document.getElementById("demo").innerHTML +=shanling;
break;
	
	}
}
	
	else{
	
	a=Math.floor(Math.random()*9);
	switch(a){


case 0:
document.getElementById("demo").innerHTML +=xiaomianyang;
break;

case 1:
document.getElementById("demo").innerHTML +=nengtianshi;
break;

case 2:
document.getElementById("demo").innerHTML +=xiaohuolong;
break;

case 3:
document.getElementById("demo").innerHTML +=daimaowang;
break;	

case 4:
document.getElementById("demo").innerHTML +=yinghui;
break;

case 5:
document.getElementById("demo").innerHTML +=sikadi;
break;

case 6:
document.getElementById("demo").innerHTML +=xingxiong;
break;

case 7:
document.getElementById("demo").innerHTML +=yeying;
break;

case 8:
document.getElementById("demo").innerHTML +=jiege;
break;
	}
}
}
function drawSrcard(){
upsr=Math.floor(Math.random()*2);
num5++;


if(upsr==0){
	decideupsr=Math.floor(Math.random()*3);
	switch(decideupsr){
	
	case 0:
document.getElementById("demo").innerHTML +=youling;
break;
	
	case 1:
document.getElementById("demo").innerHTML +=zhenli;
break;

    case 2:
document.getElementById("demo").innerHTML +=hong;
break;
	
	}
}
	
	else{
	
	sr=Math.floor(Math.random()*23);
	switch(sr){


case 0:
document.getElementById("demo").innerHTML +=yunxing;
break;

case 1:
document.getElementById("demo").innerHTML +=landu;
break;

case 2:
document.getElementById("demo").innerHTML +=puluo;
break;

case 3:
document.getElementById("demo").innerHTML +=baijin;
break;	

case 4:
document.getElementById("demo").innerHTML +=shoulin;
break;

case 5:
document.getElementById("demo").innerHTML +=yemo;
break;

case 6:
document.getElementById("demo").innerHTML +=tianhuo;
break;

case 7:
document.getElementById("demo").innerHTML +=lindong;
break;

case 8:
document.getElementById("demo").innerHTML +=deke;
break;

case 9:
document.getElementById("demo").innerHTML +=fulan;
break;

case 10:
document.getElementById("demo").innerHTML +=lapu;
break;

case 11:
document.getElementById("demo").innerHTML +=leishe;
break;

case 12:
document.getElementById("demo").innerHTML +=linguang;
break;

case 13:
document.getElementById("demo").innerHTML +=kesong;
break;

case 14:
document.getElementById("demo").innerHTML +=huafa;
break;

case 15:
document.getElementById("demo").innerHTML +=baimian;
break;

case 16:
document.getElementById("demo").innerHTML +=meier;
break;

case 17:
document.getElementById("demo").innerHTML +=sora;
break;

case 18:
document.getElementById("demo").innerHTML +=chuxue;
break;

case 19:
document.getElementById("demo").innerHTML +=shitie;
break;

case 20:
document.getElementById("demo").innerHTML +=yaxin;
break;

case 21:
document.getElementById("demo").innerHTML +=shixie;
break;

case 22:
document.getElementById("demo").innerHTML +=hemo;
break;
	}
}
	}

function drawRcard(){
r=Math.floor(Math.random()*19);
	switch(r){


case 0:
document.getElementById("demo").innerHTML +=liuxing;
break;

case 1:
document.getElementById("demo").innerHTML +=jiexi;
break;

case 2:
document.getElementById("demo").innerHTML +=baixue;
break;

case 3:
document.getElementById("demo").innerHTML +=yuanshan;
break;	

case 4:
document.getElementById("demo").innerHTML +=qingdaofu;
break;

case 5:
document.getElementById("demo").innerHTML +=hongdou;
break;

case 6:
document.getElementById("demo").innerHTML +=musi;
break;

case 7:
document.getElementById("demo").innerHTML +=shuangye;
break;

case 8:
document.getElementById("demo").innerHTML +=chanwan;
break;

case 9:
document.getElementById("demo").innerHTML +=dubin;
break;

case 10:
document.getElementById("demo").innerHTML +=liefeng;
break;

case 11:
document.getElementById("demo").innerHTML +=gumi;
break;

case 12:
document.getElementById("demo").innerHTML +=shepi;
break;

case 13:
document.getElementById("demo").innerHTML +=tiaoxiang;
break;

case 14:
document.getElementById("demo").innerHTML +=dilin;
break;

case 15:
document.getElementById("demo").innerHTML +=shenhai;
break;

case 16:
document.getElementById("demo").innerHTML +=ansuo;
break;

case 17:
document.getElementById("demo").innerHTML +=ansuo;
break;

case 18:
document.getElementById("demo").innerHTML +=li;
break;
	}

	}
function drawNcard(){
n=Math.floor(Math.random()*15);
	switch(n){


case 0:
document.getElementById("demo").innerHTML +=keluo;
break;

case 1:
document.getElementById("demo").innerHTML +=ande;
break;

case 2:
document.getElementById("demo").innerHTML +=kongbao;
break;

case 3:
document.getElementById("demo").innerHTML +=shidu;
break;	

case 4:
document.getElementById("demo").innerHTML +=yanrong;
break;

case 5:
document.getElementById("demo").innerHTML +=xiangcao;
break;

case 6:
document.getElementById("demo").innerHTML +=linyu;
break;

case 7:
document.getElementById("demo").innerHTML +=feng;
break;

case 8:
document.getElementById("demo").innerHTML +=jiansheng;
break;

case 9:
document.getElementById("demo").innerHTML +=yuejian;
break;

case 10:
document.getElementById("demo").innerHTML +=migelu;
break;

case 11:
document.getElementById("demo").innerHTML +=kati;
break;

case 12:
document.getElementById("demo").innerHTML +=furong;
break;

case 13:
document.getElementById("demo").innerHTML +=ansai;
break;

case 14:
document.getElementById("demo").innerHTML +=zilan;
break;

	}
	}

function display(){
	switch(decide){
	case 0:
drawSsrcard();
break;

case 1:
drawNormal();
break;

		
		}
	
	 
	}

	



function clickButton(){
	document.getElementById('demo').innerHTML = '';
	document.getElementById('nowa').innerHTML = '';
	document.getElementById('brave').innerHTML ='';
	document.getElementById('dark').innerHTML ='';
	c++
	document.getElementById("demo").innerHTML +='<div>'+"第"+c+"次抽卡结果："+'</div>';
	 for(var b=0;b<10;b++){
		drawCard();
		display();
	 }
	document.getElementById('nowa').innerHTML +="抽到6星数量："+num6
	document.getElementById('brave').innerHTML+="抽到5星数量："+num5
	document.getElementById('dark').innerHTML+="抽到up6星数量："+num4
		
		}
		
function cleanup(){
	
	document.getElementById('demo').innerHTML = '';
	c=0;
    index=0;
	document.getElementById('nowa').innerHTML = '';
	document.getElementById('brave').innerHTML ='';
	document.getElementById('dark').innerHTML ='';
	num6=0
	num5=0
	num4=0
	}
</script>
<div align="center">
<p2 id=nowa>

</p2>
</div>
<div align="center">
<p3 id=brave>

</p3>
</div>
<div align="center">
<p4 id=dark>

</p4>
</div>

</div>
</body>
</html>
