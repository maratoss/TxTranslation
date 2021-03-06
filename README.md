# Tx Translation & Localisation for .NET and WPF

See http://unclassified.software/source/txtranslation for further information.

## About TxTranslation

Tx is a simple yet powerful translation and localisation library for .NET applications. It manages a dictionary containing all the text snippets and phrases you need, for multiple translations. If a translation is not available in your preferred language, it can be looked up from other languages. Texts can also contain named place-holders that are filled with your data at runtime so that you don’t need to concatenate all the parts yourself in the right order. Localisation tasks like typography, number or time formatting according to the local standards are also covered.

A special feature of Tx dictionaries is that each text can have different translations depending on the subject count you’re talking about. One “day” is a different word than two “days”. This allows you to speak to your users in the most natural way, avoiding ugly parentheses or alternatives for plural words in the user interface.

All texts and translations are stored in an XML dictionary file, one per project. This XML file usually contains all languages. The dictionary can be installed with your application, or compiled right into it as an embedded resource.

The TxLib library can be used from any .NET application and is the part you’ll distribute with your application. For more portable applications, you could also directly copy the class files into your project – it’s only a few files. Its main class, Tx, is further described in the documentation.

## Text keys

All texts are associated with text keys. A text key is a short string that uniquely identifies a text or phrase and is usually used in the application source code to refer to a specific text. Text keys can be freely assigned by the developer, but there are some structuring guidelines described at the end of the documentation and a few additional requirements when using the TxEditor tool.

## Cultures

The .NET framework uses the concept of cultures to specify a combination of language and data formatting rules. Each culture has a code that describes the language and optionally a region. There are more variants but they are not supported by TxLib. Examples are “en” for the English language, “de-DE” for the German language in Germany or “pt-BR” for the Portuguese language in Brasil (as opposed to Portugal which many would probably first think of). TxLib uses these cultures to identify translations and both, region-specific and language-only codes, are used where the latter ones always serve as fallback if a translation is not found for a specific culture.

## TxEditor

The TxTranslation solution also comes with a graphical translation file editor that provides all the functionality for translating personnel that don’t necessarily have any programming experience. The TxEditor application can load a dictionary file, list all the text keys that it defines and allows viewing and editing the translation texts. It performs consistency checks to point the user to potential errors and highlight missing translations. TxEditor also makes use of TxLib itself so it is fully localisable and can be used to translate itself into other languages.

## Licence

The TxLib library, which is used in applications, is released under the terms of the GNU Lesser GPL (LGPL) licence, version 3.

The other projects (TxEditor, demos and converters) are released under the terms of the GNU GPL licence, version 3.

You can find the detailed terms and conditions in the download or on the GNU website <http://www.gnu.org/licenses/lgpl-3.0.html> and <http://www.gnu.org/licenses/gpl-3.0.html>.
