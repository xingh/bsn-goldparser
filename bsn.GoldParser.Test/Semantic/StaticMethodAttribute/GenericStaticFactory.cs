﻿// bsn GoldParser .NET Engine
// --------------------------
// 
// Copyright 2009, 2010 by Arsène von Wyss - avw@gmx.ch
//
// This file has kinly been contributed by Jan Polasek
// 
// Development has been supported by Sirius Technologies AG, Basel
// 
// Source:
// 
// https://bsn-goldparser.googlecode.com/hg/
// 
// License:
// 
// The library is distributed under the GNU Lesser General Public License:
// http://www.gnu.org/licenses/lgpl.html
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

namespace bsn.GoldParser.Semantic.StaticMethodAttribute {
	internal class GenericStaticFactory {
		[Rule(@"<Value> ::= '(' <Expression> ')'")]
		[Rule(@"<Negate Exp> ::= '-' <Value>", false)]
		[Rule(@"<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>")]
		[Rule(@"<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>")]
		public static MockGenericTokenBase Create(MockGenericTokenBase a, MockGenericTokenBase b, MockGenericTokenBase c) {
			return new MockGenericTokenBase();
		}

		[Rule(@"<Expression> ::= <Expression> '+' <Mult Exp>", typeof(MockGenericTokenBase))]
		[Rule(@"<Expression> ::= <Expression> '-' <Mult Exp>", typeof(MockGenericTokenBase))]
		[Rule(@"<Expression> ::= <Mult Exp>", typeof(MockGenericTokenBase))]
		[Rule(@"<Empty> ::= ", typeof(MockGenericTokenBase))]
		public static T Instance<T>(T a, T b, T c) where T: MockGenericTokenBase, new() {
			return new T();
		}
	}
}
