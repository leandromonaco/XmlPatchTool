Feature: Scenarios
	In order to compare 2 xml files
	As a developer
	I want to be told the xml differences

@XmlPatchTool
Scenario Outline: Compare 2 XML files
	Given I use file <File1> And <File2>
	When I compare xml files
	Then the Node Changes should be <NodeChangesValue>
	And  the Attribute Changes should be <AttributeChangesValue>
	And  the Text Changes should be <ValueChangesValue>
	And  Changes flag should be <ChangesFlag>
Examples:
		| File1					| File2					| NodeChangesValue  | AttributeChangesValue | ValueChangesValue		| ChangesFlag	|
		| FileA.xml				| FileA.xml				| 0					| 0						| 0						| false			|
#		| File1					| 1_NodeChange.xml		| 1					| 0						| 0						| true			|
#		| File1					| 1_AttributeChange.xml	| 0					| 1						| 0						| true			|
#		| File1					| 1_TextChange.xml		| 0					| 0						| 1						| true			|		


